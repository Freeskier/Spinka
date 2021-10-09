using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetEduBlocksWithMedicalService : IQuery<IEnumerable<EduBlockViewModelForMedical>> { }
}