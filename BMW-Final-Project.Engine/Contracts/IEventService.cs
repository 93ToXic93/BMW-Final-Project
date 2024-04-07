using BMW_Final_Project.Engine.Models.Event;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Event;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IEventService
    {
        Task<ICollection<AllEventsModel>> GetAllEvents();

        Task DeleteAsync(int id);

        Task<Event?> GetByIdAsync(int id);

        Task AddAsync(AddEventModel model);

        Task<bool> IsThisEventExistAsync(AddEventModel model);

        Task<bool> IsThisEventExistWhenEditAsync(EditEventModel model);

        Task<bool> IsTheDatesAreCorrectAsync(DateTime startDate, DateTime endDate);

        Task EditAsync(EditEventModel model);

    }
}
