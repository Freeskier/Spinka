﻿using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetEduBlocksAssignedToMajorEvent : IQuery<IEnumerable<EduBlockViewModel>>
    {
        public int MajorEventId { get; set; }
    }
}