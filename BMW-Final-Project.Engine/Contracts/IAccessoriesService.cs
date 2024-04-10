using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Infrastructure.Data.Models.Accessories;

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

        Task EditAsync(EditAccsesoarModel model);

        Task<bool> IsThisAccsesoarExistWhenEditAsync(EditAccsesoarModel model);

        Task<ICollection<AllMineAccsesoaries>> GetAllMineAccsesoariesAsync(Guid userId);

        Task AddAsync(int id, Guid userId);

        Task RemoveAccsesoarAsync(int id);

        Task BuyAccsesoarAsync(int id);

        Task<bool> IsThisProductIsAddedFromThisUserAsync(Guid userId, int id);
    }
}
