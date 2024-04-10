using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IMotorcycleService
    {
        Task<ICollection<MotorcycleModel>> AllAsync();

        Task EditAsync(EditMotorcycleModel model);

        Task AddAsync(AddMotorcycleModel model);

        Task AddAsync(int id , Guid userId);

        Task<ICollection<MotorcycleModel>> LoadByIdAsync(int id);

        Task<MotorcycleDetailsModel> DetailsAsync(int id);

        Task<Motorcycle?> GetByIdAsync(int id);

        Task<ICollection<TypeMotorModel>> GetTypeMotorcyclesAsync();

        Task<ICollection<ColorCategoryModel>> GetColorsAsync();

        Task<ICollection<StandardEuroModel>> GetStandardEurosAsync();

        Task DeleteAsync(int id);

        Task<bool> IsThisMotorcycleExistAsync(AddMotorcycleModel model);

        Task<bool> IsThisMotorcycleExistEditAsync(EditMotorcycleModel model);

        Task<ICollection<AllMineMotorcycles>> GetAllMineMotorcyclesAsync(Guid userId);

        Task RemoveMotorcycleAsync(int id);

        Task BuyMotorcycleAsync(int id);

        Task AddNewColorAsync(AddColorModel model);

        Task<DeleteColorPageModel> GetColorsToDeleteAsync(int currentPage, int colorsPerPage);

        Task DeleteColorAsync(int id);

        Task<bool> IsThisMotorcycleIsAdded(Guid userId, int id);
    }
}