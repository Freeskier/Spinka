using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SautinSoft;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Application.Reports.OrderPoints.Models;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Reports.OrderPoints.Commands.Handlers
{
    public class CreateReportCommandHandler : ICommandHandler<CreateOrder>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public CreateReportCommandHandler(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public async Task HandleAsync(CreateOrder command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .GetOrFailWithIncludesAsync(x => x.Id == command.EduBlockId,
                    includes: i => i.Include(x => x.AssignedTrainingFacilities)
                        .Include(x => x.AssignedAmmo)
                        .Include(x => x.AssignedVehicles)
                        .Include(x => x.AssistantInstructors)
                        .Include(x => x.AssignedTrainingGroups)
                    );

            var medicalStaff = await _unitOfWork.Repository<MedicalServiceForEduBlock>()
                .FindByWithIncludesAsync(x => x.Id == eduBlock.MedicalServiceForEduBlockId,
                    includes: i => i.Include(x => x.MedicalStaff));

            var subject = await _unitOfWork.Repository<EduBlockSubject>()
                .FindByIdAsync(eduBlock.EduBlockSubjectId);

            var area = await _unitOfWork.Repository<TrainingArea>()
                .FindByIdAsync((int)subject.TrainingAreaId);
            
            var data = new DataModelForOrder
                {
                    StartTime = eduBlock.StartTime,
                    EndOn = eduBlock.EndOn,
                    Area = area.Name,
                    Subject = subject.Subject,
                    Place = eduBlock.TrainingFacility,
                    MainInstructor = MapperHelper.HelpWithGetPersonFullNameForOrder(eduBlock.InstructorPersonId, _unitOfWork),
                    ShootingInstructor = MapperHelper.HelpWithGetPersonFullNameForOrder(eduBlock.ShootingInstructorPersonId, _unitOfWork),
                    AmmoManger = MapperHelper.HelpWithGetPersonFullNameForOrder(eduBlock.AmmoManagerPersonId, _unitOfWork),
                    DriverOne = MapperHelper.HelpWithGetPersonFullNameForOrder(eduBlock.DriverPersonId1, _unitOfWork),
                    DriverTwo = MapperHelper.HelpWithGetPersonFullNameForOrder(eduBlock.DriverPersonId2, _unitOfWork),
                    TargetPlace = eduBlock.TrainingFacility
                };

            if (data.Place == null)
            {
                var place = eduBlock.AssignedTrainingFacilities.Select(x =>
                    MapperHelper.HelpWithGetPlaceForOrder(x.TrainingFacilityId, _unitOfWork));
                
                data.Place = place.Aggregate((a, x) => a + ", " + x);

                var targetPlace = eduBlock.AssignedTrainingFacilities.Select(x =>
                    _unitOfWork.Repository<TrainingFacility>()
                        .FindByIdAsync(x.TrainingFacilityId)
                        .GetAwaiter()
                        .GetResult()
                        .Location
                    );
                
                data.TargetPlace = targetPlace.Aggregate((a, x) => a + ", " + x);
            }

            if (eduBlock.AssignedTrainingGroups.Any())
            {
                var groups = eduBlock.AssignedTrainingGroups.Select(x =>
                    _unitOfWork.Repository<TrainingGroup>()
                        .FindByIdAsync(x.TrainingGroupId)
                        .GetAwaiter()
                        .GetResult()
                        .Name
                );
                
                data.Groups = groups.Aggregate((a, x) => a + ", " + x);
            }
            
            if (eduBlock.AssignedVehicles.Any())
            {
                data.Vehicle = MapperHelper.HelpWithGetVehicleDataForOrder(eduBlock.AssignedVehicles.First().VehicleId, _unitOfWork);
            }

            if (eduBlock.AssistantInstructors.Any())
            {
                data.HelperInstructors.AddRange(eduBlock.AssistantInstructors.Select(x => new ModelForName
                    {
                        Display = MapperHelper.HelpWithGetPersonFullNameForOrder(x.PersonId, _unitOfWork)
                    })
                    .ToList());
            }
            
            if (medicalStaff != null && medicalStaff.MedicalStaff.Any())
            {
                data.MedicalStaff.AddRange(medicalStaff.MedicalStaff.Select(x => new ModelForName
                    {
                        Display = MapperHelper.HelpWithGetPersonFullNameForOrder(x.PersonId, _unitOfWork)
                    })
                    .ToList());
            }
            
            if (eduBlock.AssignedAmmo.Any())
            {
                data.Ammo.AddRange(eduBlock.AssignedAmmo.Select(x => new ModelForName
                    {
                        Display = MapperHelper.HelpWithGetAmmoDataForOrder(x, _unitOfWork)
                    })
                    .ToList());
            }
            
            var htmlToRtf = new HtmlToRtf();
            var htmlString = TemplateGenerator.GenerateOrderPoint(data);
            htmlToRtf.OpenHtml(htmlString);
            var docxBytes = htmlToRtf.ToDocx();
            var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/punkt_" +
                             DateTime.Now.Date.ToString("MM/dd/yyyy")+ "_" + Guid.NewGuid()+ ".docx";
            
            if (docxBytes != null)
            {
                await File.WriteAllBytesAsync(outputFile, docxBytes);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outputFile) 
                    {
                        UseShellExecute = true 
                    }
                );
            }
        }
    }
}