using BMW_Final_Project.Core.Contracts;
using BMW_Final_Project.Core.Models;
using BMW_Final_Project.Infrastructure.Data;

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
            throw new NotImplementedException();
        }
    }
}
