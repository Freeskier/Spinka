using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MajorEvents.ViewModels;

namespace Spinka.Application.MajorEvents.Queries.Handlers
{
    public class GetMajorEvent : IQuery<MajorEventViewModel>
    {
        public int Id { get; set; }

        public GetMajorEvent(int id)
        {
            Id = id;
        }
    }
}