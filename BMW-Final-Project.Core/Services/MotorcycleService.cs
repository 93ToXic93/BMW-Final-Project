using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Models;
using BMW_Final_Project.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static BMW_Final_Project.Infrastructure.Constants.DataConstants;

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
                    TypeMotor = x.TypeMotor.Name,
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
                    TypeMotor = x.TypeMotor.Name
                })
                .ToListAsync();

            return motorcycles;
        }
    }
}
