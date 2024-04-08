using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Infrastructure.Data.Common;

namespace BMW_Final_Project.Engine.Services
{
    public class AccessoriesService : IAccessoriesService
    {
        private readonly IRepository _repository;

        public AccessoriesService(IRepository repository)
        {
            _repository = repository;
        }


        public Task<ICollection<AllAccessoriesModel>> AllAccessoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
