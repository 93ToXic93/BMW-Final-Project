using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Event;
using BMW_Final_Project.Infrastructure.Constants;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Event;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Engine.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository _repository;

        public EventService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<AllEventsModel>> GetAllEvents()
        {
            var events = await _repository
                .AllReadOnly<Event>()
                .Where(x => x.IsActive)
                .Select(x => new AllEventsModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    EndEvent = x.EndEvent.ToString(DataConstants.DataFormatWithHours),
                    StartEvent = x.StartEvent.ToString(DataConstants.DataFormatWithHours),
                    PlaceOfTheEvent = x.PlaceOfTheEvent,
                    ImgUrl = x.ImgUrl
                })
                .ToListAsync();

            return events;
        }
    }
}
