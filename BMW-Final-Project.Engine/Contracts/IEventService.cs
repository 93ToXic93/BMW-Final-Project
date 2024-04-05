using BMW_Final_Project.Engine.Models.Event;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IEventService
    {
        Task<ICollection<AllEventsModel>> GetAllEvents();
    }
}
