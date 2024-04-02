﻿using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;

namespace BMW_Final_Project.Engine.Contracts
{
    public interface IClothService
    {
        Task<ICollection<AllClothModel>> AllAsync();

        Task<ICollection<AllClothModel>> LoadByIdAsync(int id);

        Task<ClothDetailsModel> DetailsAsync(int id);

        Task<Cloth?> GetByIdReadOnlyAsync(int id);

        Task AddAsync(int id, Guid userId);

        Task<Cloth?> GetByIdAsync(int id);

        Task RemoveClothAsync(int id);

        Task<ClothBuyer?> GetByIdClothAndServicesAsync(int id);

        Task BuyClothAsync(int id);

        Task<ICollection<AllMineCloths>> GetAllMineClothsAsync(Guid userId);

        Task<ICollection<TypePersonModel>> GetTypesAsync();

        Task<ICollection<SizeModel>> GetSizesAsync();

        Task<ICollection<ClothCollectionModel>> GetClothCollectionsAsync();

        Task<bool> IsThisClothExistAsync(AddClothModel model);

        Task AddAsync(AddClothModel model);
    }
}