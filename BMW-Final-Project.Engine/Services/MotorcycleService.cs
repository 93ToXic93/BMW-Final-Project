using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BMW_Final_Project.Engine.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IRepository _repository;

        public MotorcycleService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<MotorcycleModel>> AllAsync()
        {
            var motorcycles = await _repository
                .AllReadOnly<Motorcycle>()
                .Where(x => x.IsActive)
                .Select(x => new MotorcycleModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Year = x.Year.Year.ToString(),
                    Price = x.Price.ToString("F"),
                    Amount = x.Amount
                })
                .ToListAsync();

            return motorcycles;
        }

        public async Task EditAsync(EditMotorcycleModel model)
        {
            var motorcycleEdited = await GetByIdAsync(model.Id);

            if (motorcycleEdited == null)
            {
                throw new NullReferenceException();
            }

            motorcycleEdited.Amount = model.Amount;
            motorcycleEdited.ImageUrl = model.ImageUrl;
            motorcycleEdited.Model = model.Model;
            motorcycleEdited.CC = model.CC;
            motorcycleEdited.ColorCategoryId = model.ColorCategoryId;
            motorcycleEdited.DTC = model.DTC;
            motorcycleEdited.FrontBreak = model.FrontBreak;
            motorcycleEdited.RearBreak = model.RearBreak;
            motorcycleEdited.TankCapacity = model.TankCapacity;
            motorcycleEdited.TypeMotorId = model.TypeMotorId;
            motorcycleEdited.Transmission = model.Transmission;
            motorcycleEdited.Kg = model.Kg;
            motorcycleEdited.Price = model.Price;
            motorcycleEdited.HorsePowers = model.HorsePowers;
            motorcycleEdited.SeatHeightMm = model.SeatHeightMm;
            motorcycleEdited.StandardEuroId = model.StandardEuroId;
            motorcycleEdited.Year = model.Year;

            await _repository.SaveChangesAsync();

        }

        public async Task AddAsync(AddMotorcycleModel model)
        {
            if (await IsThisMotorcycleExistButDeletedAsync(model))
            {
                var motorcycleToAdd = await GetByNameDeletedMotorcycleAsync(model.Model);

                motorcycleToAdd.IsActive = true;
                motorcycleToAdd.Amount = model.Amount;
                motorcycleToAdd.ImageUrl = model.ImageUrl;
                motorcycleToAdd.Model = model.Model;
                motorcycleToAdd.CC = model.CC;
                motorcycleToAdd.ColorCategoryId = model.ColorCategoryId;
                motorcycleToAdd.DTC = model.DTC;
                motorcycleToAdd.FrontBreak = model.FrontBreak;
                motorcycleToAdd.RearBreak = model.RearBreak;
                motorcycleToAdd.TankCapacity = model.TankCapacity;
                motorcycleToAdd.TypeMotorId = model.TypeMotorId;
                motorcycleToAdd.Transmission = model.Transmission;
                motorcycleToAdd.Kg = model.Kg;
                motorcycleToAdd.Price = model.Price;
                motorcycleToAdd.HorsePowers = model.HorsePowers;
                motorcycleToAdd.SeatHeightMm = model.SeatHeightMm;
                motorcycleToAdd.StandardEuroId = model.StandardEuroId;
                motorcycleToAdd.Year = model.Year;

                await _repository.SaveChangesAsync();

            }
            else
            {
                Motorcycle motorcycle = new Motorcycle()
                {
                    Id = model.Id,
                    ImageUrl = model.ImageUrl,
                    Model = model.Model,
                    Amount = model.Amount,
                    CC = model.CC,
                    BuyerId = model.BuyerId,
                    ColorCategoryId = model.ColorCategoryId,
                    DTC = model.DTC,
                    FrontBreak = model.FrontBreak,
                    RearBreak = model.RearBreak,
                    TankCapacity = model.TankCapacity,
                    TypeMotorId = model.TypeMotorId,
                    Transmission = model.Transmission,
                    IsActive = true,
                    Kg = model.Kg,
                    Price = model.Price,
                    HorsePowers = model.HorsePowers,
                    SeatHeightMm = model.SeatHeightMm,
                    StandardEuroId = model.StandardEuroId,
                    Year = model.Year,
                };

                await _repository.AddAsync(motorcycle);

                await _repository.SaveChangesAsync();
            }

        }

        public async Task AddAsync(int id, Guid userId)
        {
            var motorcycleToAdd = await GetByIdAsync(id);

            if (motorcycleToAdd == null)
            {
                throw new ArgumentNullException();
            }

            if (!(motorcycleToAdd.MotorcycleBuyers.Any(x => x.Motorcycle.Id == id && x.BuyerId == userId || motorcycleToAdd.Amount == 0)))
            {
                var motorcycle = new MotorcycleBuyers()
                {
                    MotorcycleId = motorcycleToAdd.Id,
                    BuyerId = userId
                };

                if (motorcycleToAdd.Amount > 0)
                {
                    motorcycleToAdd.Amount -= 1;

                    await _repository.AddAsync(motorcycle);

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

        public async Task<ICollection<MotorcycleModel>> LoadByIdAsync(int id)
        {
            var motorcycles = await _repository
                .AllReadOnly<Motorcycle>()
                .Where(x => x.IsActive && x.TypeMotor.Id == id)
                .Select(x => new MotorcycleModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Year = x.Year.Year.ToString(),
                    Price = x.Price.ToString("F"),
                    Amount = x.Amount
                })
                .ToListAsync();

            return motorcycles;
        }

        public async Task<MotorcycleDetailsModel> DetailsAsync(int id)
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
                .AllReadOnly<Motorcycle>()
                .Where(x => x.Id == id && x.IsActive)
                .Select(x => new MotorcycleDetailsModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price.ToString(CultureInfo.InvariantCulture),
                    Model = x.Model,
                    Amount = x.Amount,
                    TankCapacity = x.TankCapacity,
                    CC = x.CC,
                    DTC = x.DTC,
                    FrontBreak = x.FrontBreak,
                    Transmission = x.Transmission,
                    StandardEuro = x.StandardEuro.Name,
                    SeatHeightMm = x.SeatHeightMm,
                    RearBreak = x.RearBreak,
                    HorsePowers = x.HorsePowers,
                    Kg = x.Kg,
                    ColorCategory = x.ColorCategory.Name
                })
                .FirstOrDefaultAsync();

            if (modelDetails == null)
            {
                throw new NullReferenceException();
            }


            return modelDetails;

        }

        public async Task<ICollection<TypeMotorModel>> GetTypeMotorcyclesAsync()
        {
            var motoTypes = await _repository
                .AllReadOnly<TypeMotor>()
                .Select(x => new TypeMotorModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return motoTypes;
        }

        public async Task<ICollection<ColorCategoryModel>> GetColorsAsync()
        {
            var motoColors = await _repository
                .AllReadOnly<ColorCategory>()
                .Where(x => x.IsActive)
                .Select(x => new ColorCategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return motoColors;
        }

        public async Task<ICollection<StandardEuroModel>> GetStandardEurosAsync()
        {
            var motoColors = await _repository
                .AllReadOnly<StandardEuro>()
                .Select(x => new StandardEuroModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return motoColors;
        }

        public async Task DeleteAsync(int id)
        {
            var motorcycle = await GetByIdAsync(id);

            if (motorcycle == null)
            {
                throw new ArgumentNullException();
            }

            if (id != motorcycle.Id)
            {
                throw new ArgumentException("Not found");
            }

            motorcycle.IsActive = false;

            await _repository.SaveChangesAsync();
        }

        public async Task<bool> IsThisMotorcycleExistAsync(AddMotorcycleModel model)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>().AnyAsync(x => x.IsActive == true && x.Model == model.Model);

            return motorcycle;
        }

        public async Task<bool> IsThisMotorcycleExistEditAsync(EditMotorcycleModel model)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>().AnyAsync(x => x.IsActive == true && x.Model == model.Model);

            return motorcycle;
        }

        public async Task<ICollection<AllMineMotorcycles>> GetAllMineMotorcyclesAsync(Guid userId)
        {
            var motorcycles = await _repository
                .AllReadOnly<MotorcycleBuyers>()
                .Where(x => x.BuyerId == userId && x.Motorcycle.IsActive)
                .Select(x => new AllMineMotorcycles()
                {
                    Id = x.Motorcycle.Id,
                    ImageUrl = x.Motorcycle.ImageUrl,
                    Year = x.Motorcycle.Year.Year.ToString(),
                    Price = x.Motorcycle.Price.ToString("F"),
                    ColorCategory = x.Motorcycle.ColorCategory.Name,
                })
                .ToListAsync();

            return motorcycles;

        }

        public async Task RemoveMotorcycleAsync(int id)
        {

            var motorcycleToRemove = await GetByIdMotorsAndServicesAsync(id);

            var motorcycle = await GetByIdAsync(id);

            if (motorcycleToRemove == null)
            {
                throw new ArgumentNullException();
            }

            if (motorcycle == null)
            {
                throw new ArgumentNullException();
            }

            motorcycle.Amount += 1;

            _repository.Remove(motorcycleToRemove);

            await _repository.SaveChangesAsync();
        }

        public async Task BuyMotorcycleAsync(int id)
        {
            var motorcycleToRemove = await GetByIdMotorsAndServicesAsync(id);


            if (motorcycleToRemove == null)
            {
                throw new ArgumentNullException();
            }

            _repository.Remove(motorcycleToRemove);

            await _repository.SaveChangesAsync();
        }

        public async Task AddNewColorAsync(AddColorModel model)
        {

            if (await _repository.AllReadOnly<ColorCategory>().AnyAsync(x => x.Name == model.Name && x.IsActive))
            {
                throw new ArgumentException("There is already one!");
            }
            else if (await _repository.AllReadOnly<ColorCategory>().AnyAsync(x => x.Name == model.Name && x.IsActive == false))
            {
                var colorToAddAgain = await _repository.All<ColorCategoryModel>()
                    .FirstAsync(x => x.Name == model.Name);

                colorToAddAgain.IsActive = true;

                await _repository.SaveChangesAsync();
            }
            else
            {
                ColorCategory color = new ColorCategory()
                {
                    IsActive = true,
                    Name = model.Name
                };

                await _repository.AddAsync(color);


                await _repository.SaveChangesAsync();
            }
        }

        public async Task<DeleteColorPageModel> GetColorsToDeleteAsync(int currentPage, int colorsPerPage)
        {
            var motoColors = _repository.AllReadOnly<ColorCategory>();

            var colors = await motoColors
                .Where(x => x.IsActive)
                .Skip((currentPage - 1) * colorsPerPage)
                .Take(colorsPerPage)
                .Select(c => new DeleteColorModel
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    Name = c.Name
                })
                .ToListAsync();

            var totalCount = await motoColors.CountAsync();

            return new DeleteColorPageModel
            {
                Colors = colors,
                TotalCount = totalCount,
                ColorsPerPage = colorsPerPage,
                CurrentPage = currentPage,
            };
        }

        public async Task<Motorcycle?> GetByIdAsync(int id)
        {
            var motorcycle = await _repository.All<Motorcycle>()
                .Include(x => x.MotorcycleBuyers)
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            if (motorcycle == null)
            {
                throw new ArgumentNullException();
            }

            return motorcycle;
        }


        private async Task<Motorcycle?> GetByIdReadOnlyAsync(int id)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>()
             .Where(x => x.Id == id && x.IsActive)
             .FirstOrDefaultAsync();

            return motorcycle;
        }
        public async Task DeleteColorAsync(int id)
        {
            var colorToDel = await _repository.All<ColorCategory>()
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            if (colorToDel == null)
            {
                throw new ArgumentNullException();
            }

            colorToDel.IsActive = false;

            await _repository.SaveChangesAsync();
        }
        private async Task<bool> IsThisMotorcycleExistButDeletedAsync(AddMotorcycleModel model)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>().AnyAsync(x => x.IsActive == false && x.Model == model.Model);

            return motorcycle;
        }
        private async Task<Motorcycle?> GetByNameDeletedMotorcycleAsync(string name)
        {
            var motorcycle = await _repository.All<Motorcycle>()
                .Where(x => x.Model == name && x.IsActive == false)
                .FirstOrDefaultAsync();

            return motorcycle;
        }
        private async Task<MotorcycleBuyers?> GetByIdMotorsAndServicesAsync(int id)
        {
            var motorcycle = await _repository.All<MotorcycleBuyers>()
                .Where(x => x.MotorcycleId == id)
                .FirstOrDefaultAsync();

            return motorcycle;
        }
    }
}
