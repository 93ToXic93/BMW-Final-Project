using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Models;
using BMW_Final_Project.Infrastructure.Data;
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
                    Price = x.Price,
                    Year = x.Year.ToString(DataFormat),
                    TypeMotor = x.TypeMotor.Name
                })
                .ToListAsync();

            return motorcycles;
        }
    }
}
