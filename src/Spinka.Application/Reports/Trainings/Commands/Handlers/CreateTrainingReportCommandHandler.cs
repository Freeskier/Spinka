using System;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Reports.Trainings.Models;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Reports.Trainings.Commands.Handlers
{
    public class CreateTrainingReportCommandHandler : ICommandHandler<CreateTrainingReport>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter _converter;
        
        public CreateTrainingReportCommandHandler(IUnitOfWork unitOfWork, IConverter converter)
        {
            _unitOfWork = unitOfWork;
            _converter = converter;
        }
        
        public async Task HandleAsync(CreateTrainingReport command)
        {
            var eduBlocks = await _unitOfWork.Repository<EduBlock>()
                .FindAllWithIncludesAsync(x => x.StartTime.Date >= command.StartTime.Date 
                                               && x.EndOn.Date <= command.EndOn.Date,
                    includes: i => i.Include(x => x.AssignedAmmo)
                        .Include(x => x.AssignedTrainingFacilities)
                );

            var enumerable = eduBlocks.ToList();
            var data = enumerable.Select(x => new DataModelForTraining
                {
                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndOn = x.EndOn,
                    Subject = _unitOfWork.Repository<EduBlockSubject>()
                        .FindByIdAsync(x.EduBlockSubjectId)
                        .GetAwaiter()
                        .GetResult()
                        .Subject,
                    TrainingArea =  _unitOfWork.Repository<TrainingArea>()
                        .FindByIdAsync((int)_unitOfWork.Repository<EduBlockSubject>()
                            .FindByIdAsync(x.EduBlockSubjectId)
                            .GetAwaiter()
                            .GetResult()
                            .TrainingAreaId)
                        .GetAwaiter()
                        .GetResult()
                        .Name,
                    Place = x.TrainingFacility,
                    MainInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(x.InstructorPersonId, _unitOfWork)
                })
                .OrderBy(x => x.StartTime)
                .ToList();

            foreach (var eduBlock in enumerable)
            {
                foreach (var item in data)
                {
                    if (eduBlock.Id == item.Id && item.Place == null)
                    {
                        var place = eduBlock.AssignedTrainingFacilities.Select(x =>
                            MapperHelper.HelpWithGetPlaceForOrder(x.TrainingFacilityId, _unitOfWork));
                
                        item.Place = place.Aggregate((a, x) => a + ", " + x);
                    }

                    if (eduBlock.Id == item.Id && eduBlock.AssignedAmmo.Any())
                    {
                        var ammoTmp = eduBlock.AssignedAmmo.Select(x =>
                            MapperHelper.HelpWithGetAmmoDataForOrder(x, _unitOfWork));
                        
                        item.Ammo = ammoTmp.Aggregate((a, x) => a + ", " + x);
                    }

                    if (eduBlock.Id == item.Id && !eduBlock.AssignedAmmo.Any())
                    {
                        item.Ammo = "Brak";
                    }
                }
            }
            
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings {Top = 10},
                DocumentTitle = "Plan Szkolenia",
                Out = $"{Consts.AssetsPath}plan_szkolenia_{DateTime.Now:dd.MM.yyyy_H:mm}_{Guid.NewGuid()}.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GenerateTrainingReport(data),
                HeaderSettings = {FontName = "Arial", FontSize = 9, Right = "Strona [page] z [toPage]"},
                FooterSettings =
                {
                    FontName = "Arial", FontSize = 9, Line = true,
                    Center = $"Wygenerowano: {DateTime.Now.Date:dd.MM.yyyy}"
                },
                IncludeInOutline = true
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = {objectSettings}
            };

            _converter.Convert(pdf);
        }
    }
}