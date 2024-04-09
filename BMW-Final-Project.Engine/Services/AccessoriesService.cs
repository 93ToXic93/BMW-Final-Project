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
    }
}
