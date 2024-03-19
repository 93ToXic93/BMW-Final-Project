﻿using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IMotorcycleService
    {
        Task<ICollection<MotorcycleModel>> AllAsync();

        Task EditAsync(EditMotorcycleModel model);

        Task AddAsync(AddMotorcycleModel model);

        Task AddAsync(int id , string userId);

        Task<ICollection<MotorcycleModel>> LoadById(int id);

        Task<MotorcycleDetailsModel> DetailsAsync(int id);

        Task<Motorcycle?> GetByIdReadOnlyAsync(int id);

        Task<Motorcycle?> GetByIdAsync(int id);

        Task<Motorcycle?> GetByNameDeletedMotorcycleAsync(string name);

        Task<ICollection<TypeMotorModel>> GetTypeMotorcyclesAsync();

        Task<ICollection<ColorCategoryModel>> GetColorsAsync();

        Task<ICollection<StandardEuroModel>> GetStandardEurosAsync();

        Task DeleteAsync(int id);

        Task<bool> IsThisMotorcycleExistAsync(AddMotorcycleModel model);

        Task<bool> IsThisMotorcycleExistButDeletedAsync(AddMotorcycleModel model);

        Task<ICollection<AllMineMotorcycles>> GetAllMineMotorcyclesAsync(string userId);

    }
}