using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlockSubjects.ViewModels;

namespace Spinka.Application.EduBlockSubjects.Queries
{
    public class GetEduBlockSubjects : IQuery<IEnumerable<EduBlockSubjectViewModel>> { }
}