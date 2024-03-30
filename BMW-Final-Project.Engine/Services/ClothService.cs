using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Cloths;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BMW_Final_Project.Engine.Services
{
    public class ClothService : IClothService
    {
        private readonly IRepository _repository;

        public ClothService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<AllClothModel>> AllAsync()
        {
            var cloths = await _repository
                .AllReadOnly<Cloth>()
                .Where(x => x.IsActive)
                .Select(x => new AllClothModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Name = x.Name,
                    ClothCollection = x.ClothCollection.Name,
                    Price = x.Price.ToString("F"),
                    Amount = x.Amount
                })
                .ToListAsync();

            return cloths;
        }

        public async Task<ICollection<AllClothModel>> LoadByIdAsync(int id)
        {
            var cloths = await _repository
                .AllReadOnly<Cloth>()
                .Where(x => x.IsActive && x.TypePerson.Id == id)
                .Select(x => new AllClothModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Name = x.Name,
                    ClothCollection = x.ClothCollection.Name,
                    Price = x.Price.ToString("F"),
                    Amount = x.Amount
                })
                .ToListAsync();

            return cloths;
        }

        public async Task<ClothDetailsModel> DetailsAsync(int id)
        {
            var model = await GetByIdReadOnlyAsync(id);

            if (model == null)
            {
                throw new NullReferenceException();
            }

            if (id != model.Id)
            {
                throw new ArgumentException("model id isn't correct!");
            }

            var modelDetails = await _repository
                .AllReadOnly<Cloth>()
                .Where(x => x.Id == id && x.IsActive)
                .Select(x => new ClothDetailsModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price.ToString(CultureInfo.InvariantCulture),
                    Name = x.Name,
                    Description = x.Description,
                    ClothCollection = x.ClothCollection.Name,
                    Size = x.Size.Name
                })
                .FirstOrDefaultAsync();

            if (modelDetails == null)
            {
                throw new NullReferenceException();
            }


            return modelDetails;
        }

        public async Task<Cloth?> GetByIdReadOnlyAsync(int id)
        {
            var motorcycle = await _repository.AllReadOnly<Cloth>()
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            return motorcycle;
        }

        public async Task AddAsync(int id, Guid userId)
        {
            var clothToAdd = await GetByIdAsync(id);

            if (clothToAdd == null)
            {
                throw new ArgumentNullException();
            }

            if (!(clothToAdd.ClothBuyers.Any(x => x.Cloth.Id == id && x.BuyerId == userId || clothToAdd.Amount == 0)))
            {
                var cloth = new ClothBuyer()
                {
                    ClothId = clothToAdd.Id,
                    BuyerId = userId
                };

                if (clothToAdd.Amount > 0)
                {
                    clothToAdd.Amount -= 1;

                    await _repository.AddAsync(cloth);

                    await _repository.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("There is no more of this motor!");
                }

            }
            else
            {
                throw new ArgumentException("Already reserved it or its 0 amount!");
            }
        }

        public async Task<Cloth?> GetByIdAsync(int id)
        {
            var cloth = await _repository.All<Cloth>()
                .Include(x => x.ClothBuyers)
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            if (cloth == null)
            {
                throw new ArgumentNullException();
            }

            return cloth;
        }

        public async Task RemoveClothAsync(int id)
        {
            var clothToRemove = await GetByIdClothAndServicesAsync(id);

            var cloth = await GetByIdAsync(id);

            if (clothToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (cloth == null)
            {
                throw new ArgumentNullException();
            }

            cloth.Amount += 1;

            _repository.Remove(clothToRemove);

            await _repository.SaveChangesAsync();
        }

        public async Task<ClothBuyer?> GetByIdClothAndServicesAsync(int id)
        {
            var motorcycle = await _repository.All<ClothBuyer>()
                .Where(x => x.ClothId == id)
                .FirstOrDefaultAsync();

            return motorcycle;
        }

        public async Task BuyClothAsync(int id)
        {
            var clothToRemove = await GetByIdClothAndServicesAsync(id);

            var cloth = await GetByIdAsync(id);

            if (clothToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (cloth == null)
            {
                throw new ArgumentNullException();
            }

            _repository.Remove(clothToRemove);

            await _repository.SaveChangesAsync();
        }
    }
}