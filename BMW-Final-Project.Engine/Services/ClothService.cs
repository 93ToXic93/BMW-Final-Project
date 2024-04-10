using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Cloth;
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

        public async Task<ICollection<AllMineCloths>> GetAllMineClothsAsync(Guid userId)
        {
            var cloths = await _repository
                .AllReadOnly<ClothBuyer>()
                .Where(x => x.BuyerId == userId && x.Cloth.IsActive)
                .Select(x => new AllMineCloths()
                {
                    Id = x.Cloth.Id,
                    ImgUrl = x.Cloth.ImgUrl,
                    Name = x.Cloth.Name,
                    Price = x.Cloth.Price.ToString("F"),
                    Size = x.Cloth.Size.Name,
                })
                .ToListAsync();

            return cloths;

        }

        public async Task<ICollection<TypePersonModel>> GetTypesAsync()
        {
            var personTypes = await _repository
                .AllReadOnly<TypePerson>()
                .Select(x => new TypePersonModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return personTypes;
        }

        public async Task<ICollection<SizeModel>> GetSizesAsync()
        {
            var clothSize = await _repository
                .AllReadOnly<Size>()
                .Select(x => new SizeModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return clothSize;
        }

        public async Task<ICollection<ClothCollectionModel>> GetClothCollectionsAsync()
        {
            var clothCollection = await _repository
                .AllReadOnly<ClothCollection>()
                .Select(x => new ClothCollectionModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return clothCollection;
        }

        public async Task<bool> IsThisClothExistAsync(AddClothModel model)
        {
            var cloth = await _repository.AllReadOnly<Cloth>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return cloth;
        }

        public async Task EditAsync(EditClothModel model)
        {
            var clothEdited = await GetByIdAsync(model.Id);

            if (clothEdited == null)
            {
                throw new NullReferenceException();
            }

            clothEdited.Amount = model.Amount;
            clothEdited.ImgUrl = model.ImgUrl;
            clothEdited.Price = model.Price;
            clothEdited.Description = model.Description;
            clothEdited.Name = model.Name;
            clothEdited.SizeId = model.SizeId;
            clothEdited.ClothCollectionId = model.ClothCollectionId;
            clothEdited.TypePersonId = model.TypePersonId;

            await _repository.SaveChangesAsync();
        }

        public async Task AddAsync(AddClothModel model)
        {
            if (await IsThisClothExistButDeletedAsync(model))
            {
                var clothToAdd = await GetByNameDeletedClothAsync(model.Name);

                clothToAdd.Id = model.Id;
                clothToAdd.ImgUrl = model.ImgUrl;
                clothToAdd.Name = model.Name;
                clothToAdd.Amount = model.Amount;
                clothToAdd.BuyerId = model.BuyerId;
                clothToAdd.IsActive = true;
                clothToAdd.Price = model.Price;
                clothToAdd.Description = model.Description;
                clothToAdd.SizeId = model.SizeId;
                clothToAdd.TypePersonId = model.TypePersonId;
                clothToAdd.ClothCollectionId = model.ClothCollectionId;

                await _repository.SaveChangesAsync();

            }
            else
            {
                Cloth cloth = new Cloth()
                {
                    Id = model.Id,
                    ImgUrl = model.ImgUrl,
                    Name = model.Name,
                    Amount = model.Amount,
                    BuyerId = model.BuyerId,
                    IsActive = true,
                    Price = model.Price,
                    Description = model.Description,
                    SizeId = model.SizeId,
                    TypePersonId = model.TypePersonId,
                    ClothCollectionId = model.ClothCollectionId
                   
                };

                await _repository.AddAsync(cloth);

                await _repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var cloth = await GetByIdAsync(id);

            if (cloth == null)
            {
                throw new ArgumentNullException();
            }

            if (id != cloth.Id)
            {
                throw new ArgumentException("Not found");
            }

            cloth.IsActive = false;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsThisClothExistWhenEditAsync(EditClothModel model)
        {
            var cloth = await _repository.AllReadOnly<Cloth>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return cloth;
        }

        public async Task<bool> IsThisProductIsAddedAsync(Guid userId, int id)
        {
            return await _repository.AllReadOnly<ClothBuyer>()
                .AnyAsync(x => x.BuyerId == userId && x.ClothId == id);
        }


        private async Task<Cloth?> GetByIdReadOnlyAsync(int id)
        {
            var motorcycle = await _repository.AllReadOnly<Cloth>()
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            return motorcycle;
        }
        private async Task<Cloth?> GetByNameDeletedClothAsync(string name)
        {
            var cloth = await _repository.All<Cloth>()
                .Where(x => x.Name == name && x.IsActive == false)
                .FirstOrDefaultAsync();

            return cloth;
        }
        private async Task<bool> IsThisClothExistButDeletedAsync(AddClothModel model)
        {
            var motorcycle = await _repository.AllReadOnly<Cloth>().AnyAsync(x => x.IsActive == false && x.Name == model.Name);

            return motorcycle;
        }
        private async Task<ClothBuyer?> GetByIdClothAndServicesAsync(int id)
        {
            var motorcycle = await _repository.All<ClothBuyer>()
                .Where(x => x.ClothId == id)
                .FirstOrDefaultAsync();

            return motorcycle;
        }
    }
}