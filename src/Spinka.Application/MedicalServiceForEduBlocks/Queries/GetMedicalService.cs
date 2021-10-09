using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MedicalServiceForEduBlocks.ViewModels;

namespace Spinka.Application.MedicalServiceForEduBlocks.Queries
{
    public class GetMedicalService : IQuery<MedicalServiceForEduBlockViewModel>
    {
        public int EduBlockId { get; set; }
    }
}