using System;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Reports.Ammo.Models;
using Spinka.Application.Utils;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using AmmoEntity = Spinka.Domain.Models.Ammo;

namespace Spinka.Application.Reports.Ammo.Commands.Handlers
{
    public class CreateAmmoReportCommandHandler : ICommandHandler<CreateAmmoReport>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter _converter;

        public CreateAmmoReportCommandHandler(IUnitOfWork unitOfWork, IConverter converter)
        {
            _unitOfWork = unitOfWork;
            _converter = converter;
        }
        
        public async Task HandleAsync(CreateAmmoReport command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == command.EduBlockId,
                    includes: i => i.Include(x => x.AssignedTrainingGroups)
                        .Include(x => x.AssignedAmmo));

            var unitDepartment = await _unitOfWork.Repository<TrainingGroupsInDepartment>()
                .FindByIdAsync(eduBlock.AssignedTrainingGroups.First().TrainingGroupId);
            
            var unitDepartmentName = await _unitOfWork.Repository<UnitDepartment>()
                .FindByIdAsync(unitDepartment.UnitDepartmentsId);
            
            var subject = await _unitOfWork.Repository<EduBlockSubject>()
                .FindByIdAsync(eduBlock.EduBlockSubjectId);
            
            var data = new DataModelForAmmo
                {
                    UnitDepartment = unitDepartmentName.Name,
                    MainInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.InstructorPersonId, _unitOfWork),
                    EduBlockDate = eduBlock.StartTime.Date,
                    AmmoManager = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.AmmoManagerPersonId, _unitOfWork),
                    OrderNumber = command.OrderNumber,
                    OrderDate = command.OrderDate,
                    ShootingInstructor = MapperHelper.HelpWithGetPersonFullNameForAmmoReport(eduBlock.ShootingInstructorPersonId, _unitOfWork),
                    EduBlockSubject = subject.Subject.Substring(subject.Subject.IndexOf(' ') + 1),
                    EduBlockSubjectCode = subject.Subject.Split (' ', 2).First()
                };

            var id = 0;
            
            data.Ammo.AddRange(eduBlock.AssignedAmmo.Select(x => new AmmoModel
                {
                    Idx = ++id,
                    Name = _unitOfWork.Repository<AmmoEntity>()
                        .FindByIdAsync(x.AmmoId)
                        .GetAwaiter()
                        .GetResult()
                        .Name,
                    OperationCode = 261,
                    AmmoIdx = _unitOfWork.Repository<AmmoEntity>()
                        .FindByIdAsync(x.AmmoId)
                        .GetAwaiter()
                        .GetResult()
                        .LogIndex,
                    Measure = MapperHelper.HelpWithAmmoMeasureForAmmoReport(x.AmmoId, _unitOfWork),
                    Quantity = x.Quantity,
                    IdForSecondPage = ConvertIdToOtherId(id)
                }));
            
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings {Top = 10},
                DocumentTitle = "ZPZ",
                Out = $"{Consts.AssetsPath}zpz_{DateTime.Now:dd.MM.yyyy_H:mm}_{Guid.NewGuid()}.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GenerateAmmoReport(data),
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

        private static string ConvertIdToOtherId(int id)
        {
            if (id < 10)
            {
                return $"00{id}";
            }

            if (id >= 10 && id < 100)
            {
                return $"0{id}";
            }

            return id.ToString();
        }
    }
}