using BMW_Final_Project.Core.Models;

namespace BMW_Final_Project.Core.Contracts
{
    public interface IMotorcycleService
    {
        Task<ICollection<MotorcycleModel>> AllAsync();
    }
}
