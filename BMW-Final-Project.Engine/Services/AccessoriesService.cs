using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Accessories;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Engine.Services
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IRepository _repository;

        public AccessoriesService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<ICollection<AllAccessoriesModel>> AllAccessoriesAsync()
        {
            var model = await _repository.AllReadOnly<Accessor>()
                .Where(x => x.IsActive)
                .Select(x => new AllAccessoriesModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Name = x.Name,
                    Price = x.Price.ToString("F"),
                    Amount = x.Amount
                }).ToListAsync();

            return model;
        }

        public async Task<ICollection<AllAccessoriesModel>> LoadByIdAsync(int id)
        {
            var model = await _repository
                .AllReadOnly<Accessor>()
                .Where(x => x.IsActive && x.ItemType.Id == id)
                .Select(x => new AllAccessoriesModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price.ToString("F"),
                    Name = x.Name,
                    Amount = x.Amount
                }).ToListAsync();

            return model;
        }

        public async Task<bool> IsThisAccsesoarExistAsync(AddAccsessoarModel model)
        {
            var accsesoar = await _repository.AllReadOnly<Accessor>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return accsesoar;
        }

        public async Task AddAsync(AddAccsessoarModel model)
        {
            if (await IsThisAccsesoarExistButDeletedAsync(model))
            {
                var accessoroToAdd = await GetByNameDeletedAccsesoarAsync(model.Name);

                accessoroToAdd.IsActive = true;
                accessoroToAdd.Amount = model.Amount;
                accessoroToAdd.ImgUrl = model.ImgUrl;
                accessoroToAdd.Price = model.Price;
                accessoroToAdd.Name = model.Name;
                accessoroToAdd.ItemTypeId = model.ItemTypeId;

                await _repository.SaveChangesAsync();

            }
            else
            {
                Accessor accessor = new Accessor()
                {
                    Id = model.Id,
                    ImgUrl = model.ImgUrl,
                    Amount = model.Amount,
                    BuyerId = model.BuyerId,
                    IsActive = true,
                    Price = model.Price,
                    Name = model.Name,
                    ItemTypeId = model.ItemTypeId,
                };

                await _repository.AddAsync(accessor);

                await _repository.SaveChangesAsync();
            }
        }

        public async Task<ICollection<ItemTypeModel>> GetItemTypeModelAsync()
        {
            var itemTypes = await _repository
                .AllReadOnly<ItemType>()
                .Select(x => new ItemTypeModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return itemTypes;
        }

        public async Task DeleteAsync(int id)
        {
            var accsesoar = await GetByIdAsync(id);

            if (accsesoar == null)
            {
                throw new ArgumentNullException();
            }

            if (id != accsesoar.Id)
            {
                throw new ArgumentException("Not found");
            }

            accsesoar.IsActive = false;

            await _repository.SaveChangesAsync();
        }

        public async Task<Accessor?> GetByIdAsync(int id)
        {
            var accessor = await _repository.All<Accessor>()
                .Include(x => x.AccessorBuyers)
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            if (accessor == null)
            {
                throw new ArgumentNullException();
            }

            return accessor;
        }

        public async Task EditAsync(EditAccsesoarModel model)
        {
            var accsesoarToEdit = await GetByIdAsync(model.Id);
             
            if (accsesoarToEdit == null)
            {
                throw new NullReferenceException();
            }

            accsesoarToEdit.Amount = model.Amount;
            accsesoarToEdit.ImgUrl = model.ImgUrl;
            accsesoarToEdit.Price = model.Price;
            accsesoarToEdit.Name = model.Name;
            accsesoarToEdit.ItemTypeId = model.ItemTypeId;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsThisAccsesoarExistWhenEditAsync(EditAccsesoarModel model)
        {
            var accsesoar = await _repository.AllReadOnly<Accessor>().AnyAsync(x => x.IsActive == true && x.Name == model.Name);

            return accsesoar;
        }


        private async Task<Accessor?> GetByNameDeletedAccsesoarAsync(string name)
        {
            var accsesoar = await _repository.All<Accessor>()
                .Where(x => x.Name == name && x.IsActive == false)
                .FirstOrDefaultAsync();

            return accsesoar;
        }

        private async Task<bool> IsThisAccsesoarExistButDeletedAsync(AddAccsessoarModel model)
        {
            var accsesoar = await _repository.AllReadOnly<Accessor>().AnyAsync(x => x.IsActive == false && x.Name == model.Name);

            return accsesoar;
        }

    }
}
