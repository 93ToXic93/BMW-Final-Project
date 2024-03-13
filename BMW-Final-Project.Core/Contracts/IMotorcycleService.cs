using BMW_Final_Project.Core.Models;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;

namespace BMW_Final_Project.Core.Contracts
{
    public interface IMotorcycleService
    {
        Task<ICollection<MotorcycleModel>> AllAsync();
        Task<ICollection<MotorcycleModel>> LoadById(int id);

        Task<MotorcycleDetailsModel> DetailsAsync(int id);

        Task<Motorcycle?> GetByIdAsync(int id);

        Task<ICollection<TypeMotorModel>> GetTypeMotorcyclesAsync();

        Task<ICollection<ColorCategoryModel>> GetColorsAsync();

        Task<ICollection<StandardEuroModel>> GetStandardEurosAsync();


    }
}
