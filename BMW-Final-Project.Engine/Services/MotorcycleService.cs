using System.Globalization;
using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycles;
using Microsoft.EntityFrameworkCore;

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
            var model = await GetByIdAsync(id);

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
                })
                .FirstOrDefaultAsync();

            if (modelDetails == null)
            {
                throw new NullReferenceException();
            }


            return modelDetails;

        }

        public async Task<Motorcycle?> GetByIdAsync(int id)
        {
            var motorcycle = await _repository.AllReadOnly<Motorcycle>()
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
