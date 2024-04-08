using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Event;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Constants;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Event;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;
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

        public async Task DeleteAsync(int id)
        {
            var eventToRemove = await GetByIdAsync(id);

            if (eventToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (id != eventToRemove.Id)
            {
                throw new ArgumentException("Not found");
            }

            eventToRemove.IsActive = false;

            await _repository.SaveChangesAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            var eve = await _repository.All<Event>()
                .Include(x => x.EventsJoiners)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return eve;
        }

        public async Task AddAsync(AddEventModel model)
        {
            if (await IsThisEventExistButDeletedAsync(model))
            {
                var eventToAdd = await GetByNameDeletedEventAsync(model.Name);

                eventToAdd.IsActive = true;
                eventToAdd.ImgUrl = model.ImgUrl;
                eventToAdd.Name = model.Name;
                eventToAdd.EndEvent = model.EndEvent;
                eventToAdd.StartEvent = model.StartEvent;
                eventToAdd.Id = model.Id;
                eventToAdd.PlaceOfTheEvent = model.PlaceOfTheEvent;
                eventToAdd.Description = model.Description;
                eventToAdd.JoinerId = model.JoinerId;


                await _repository.SaveChangesAsync();
            }
            else
            {
                Event eventToAdd = new Event()
                {
                    IsActive = true,
                    ImgUrl = model.ImgUrl,
                    Name = model.Name,
                    EndEvent = model.EndEvent,
                    StartEvent = model.StartEvent,
                    PlaceOfTheEvent = model.PlaceOfTheEvent,
                    Description = model.Description,
                    JoinerId = model.JoinerId,
                };

                await _repository.AddAsync(eventToAdd);

                await _repository.SaveChangesAsync();
            }
        }

        public async Task<bool> IsThisEventExistAsync(AddEventModel model)
        {
            var eve = await _repository.AllReadOnly<Event>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return eve;
        }

        public async Task<bool> IsThisEventExistWhenEditAsync(EditEventModel model)
        {
            var eve = await _repository.AllReadOnly<Event>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return eve; ;
        }

        public async Task<bool> IsTheDatesAreCorrectAsync(DateTime startDate, DateTime endDate)
        {

            if (!(startDate.Date > endDate.Date))
            {
                if (startDate.Date == endDate.Date)
                {
                    if (startDate.Hour + 1 <= endDate.Hour)
                    {
                        return true;
                    }

                    return false;
                }

                return true;
            }


            return false;
        }

        public async Task EditAsync(EditEventModel model)
        {
            var eventEdited = await GetByIdAsync(model.Id);

            if (eventEdited == null)
            {
                throw new NullReferenceException();
            }

            eventEdited.Name = model.Name;
            eventEdited.Description = model.Description;
            eventEdited.EndEvent = model.EndEvent;
            eventEdited.StartEvent = model.StartEvent;
            eventEdited.ImgUrl = model.ImgUrl;
            eventEdited.PlaceOfTheEvent = model.PlaceOfTheEvent;

            await _repository.SaveChangesAsync();
        }

        public async Task<ICollection<AllMineEvents>> GetAllMineEventsAsync(Guid userId)
        {
            var events = await _repository
                .AllReadOnly<EventJoiners>()
                .Where(x => x.JoinerId == userId && x.Event.IsActive)
                .Select(x => new AllMineEvents()
                {
                    Id = x.Event.Id,
                    Description = x.Event.Description,
                    ImgUrl = x.Event.ImgUrl,
                    EndEvent = x.Event.EndEvent.ToString(DataConstants.DataFormatWithHours),
                    StartEvent = x.Event.StartEvent.ToString(DataConstants.DataFormatWithHours),
                    Name = x.Event.Name,
                    PlaceOfTheEvent = x.Event.PlaceOfTheEvent
                })
                .ToListAsync();

            return events;
        }

        public async Task AddAsync(int id, Guid userId)
        {
            var eventToAdd = await GetByIdAsync(id);

            if (eventToAdd == null)
            {
                throw new ArgumentNullException();
            }

            if (!(eventToAdd.EventsJoiners.Any(x => x.Event.Id == id && x.JoinerId == userId)))
            {
                var eve = new EventJoiners()
                {
                    EventId = eventToAdd.Id,
                    JoinerId = userId
                };

                await _repository.AddAsync(eve);

                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Already joined");
            }
        }

        public async Task RemoveEventAsync(int id, Guid userId)
        {
            var eventToRemove = await GetByIdMotorsAndServicesAsync(id);

            if (eventToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (eventToRemove.JoinerId != userId)
            {
                throw new ArgumentException("Not correct user");
            }

            _repository.Remove(eventToRemove);

            await _repository.SaveChangesAsync();
        }

        public async Task<AllJoinedUsersModel> AllJoinedUsersForEventAsync(int id, int currentPage, int joinersPerPage)
        {
            var model = await _repository.AllReadOnly<Event>()
                .Where(x => x.Id == id)
                .Include(x => x.EventsJoiners)
                .Select(x => new AllJoinedUsersModel()
                {
                    ImgUrl = x.ImgUrl,
                    Name = x.Name,
                    Joiners = x.EventsJoiners
                        .Skip((currentPage - 1) * joinersPerPage)
                        .Take(joinersPerPage)
                        .Select(x => new JoinersModel()
                        {
                            FirstName = x.Joiner.FirstName ?? string.Empty,
                            NickName = x.Joiner.Nickname ?? string.Empty
                        }).ToList()

                }).FirstOrDefaultAsync();

            var modelForCount = await _repository.AllReadOnly<EventJoiners>()
                .Where(x => x.EventId == id)
                .Select(x => new JoinersModel()).ToListAsync();

            if (model == null)
            {
                throw new NullReferenceException();
            }


            var totalCount = modelForCount.Count;


            return new AllJoinedUsersModel
            {
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                Joiners = model.Joiners,
                ColorsPerPage = joinersPerPage,
                CurrentPage = currentPage,
                TotalCount = totalCount
            };
        }

        private async Task<bool> IsThisEventExistButDeletedAsync(AddEventModel model)
        {
            var eve = await _repository.AllReadOnly<Event>().AnyAsync(x => x.IsActive == false && x.Name == model.Name);

            return eve;
        }
        private async Task<Event?> GetByNameDeletedEventAsync(string name)
        {
            var eve = await _repository.All<Event>()
                .Where(x => x.Name == name && x.IsActive == false)
                .FirstOrDefaultAsync();

            return eve;
        }
        private async Task<EventJoiners?> GetByIdMotorsAndServicesAsync(int id)
        {
            var motorcycle = await _repository.All<EventJoiners>()
                .Where(x => x.EventId == id)
                .FirstOrDefaultAsync();

            return motorcycle;
        }
    }
}
