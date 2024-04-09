using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Infrastructure.Data.Models.Accessories;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IAccessoriesService
    {
        Task<ICollection<AllAccessoriesModel>> AllAccessoriesAsync();

        Task<ICollection<AllAccessoriesModel>> LoadByIdAsync(int id);

        Task<bool> IsThisAccsesoarExistAsync(AddAccsessoarModel model);

        Task AddAsync(AddAccsessoarModel model);

        Task<ICollection<ItemTypeModel>> GetItemTypeModelAsync();

        Task DeleteAsync(int id);

        Task<Accessor?> GetByIdAsync(int id);


    }
}
