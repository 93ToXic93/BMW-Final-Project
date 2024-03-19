using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
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
                    price = x.Price.ToString("F")
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
            
            Motorcycle motorcycle = new Motorcycle()
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Model = model.Model,
                Amount = model.Amount,
                CC = model.CC,
                BuyerId = new Guid(model.BuyerId),
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


        public async Task<ICollection<MotorcycleModel>> LoadById(int id)
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

        public async Task<Motorcycle?> GetByIdReadOnlyAsync(int id)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>()
             .Where(x => x.Id == id && x.IsActive)
             .FirstOrDefaultAsync();

            return motorcycle;
        }

        public async Task<Motorcycle?> GetByIdAsync(int id)
        {
            var motorcycle = await _repository.All<Motorcycle>()
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            return motorcycle;
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
    }
}
