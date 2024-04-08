using BMW_Final_Project.Engine.Models.Accessories;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IAccessoriesService
    {
        Task<ICollection<AllAccessoriesModel>> AllAccessoriesAsync();
    }
}
