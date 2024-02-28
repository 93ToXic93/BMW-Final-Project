using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Models;
using BMW_Final_Project.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.Core.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext _context;

        public MotorcycleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<MotorcycleModel>> AllAsync()
        {
            var motorcycles = await _context.Motorcycles
                .AsNoTracking()
                .Where(x => x.IsActive)
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


        public async Task<ICollection<MotorcycleModel>> LoadById(int id)
        {
            var motorcycles = await _context.Motorcycles
                .AsNoTracking()
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
            var model = await _context.Motorcycles
                .FindAsync(id);

            if (model == null)
            {
                throw new ArgumentNullException();
            }

            if (id != model.Id)
            {
                throw new ArgumentException("model id isn't correct!");
            }

            if (model.IsActive == false)
            {
                throw new ArgumentException("This motorcycle is deleted");
            }


            var modelDetails = await _context.Motorcycles
                .Where(x => x.Id == id)
                .Select(x => new MotorcycleDetailsModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Model = x.Model,
                    Amount = x.Amount,
                    CC = x.CC,
                    DTC = x.DTC,
                    FrontBreak = x.FrontBreak,
                    HorsePowers = x.HorsePowers,
                    Kg = x.Kg,
                })
                .FirstOrDefaultAsync();

            return modelDetails;

        }
    }
}
