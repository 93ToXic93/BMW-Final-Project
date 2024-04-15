using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Services;
using BMW_Final_Project.Infrastructure.Data;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Cloth;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.UnitTests
{
    [TestFixture]
    public class ClothServiceTesting
    {
        private IClothService _clothService;
        private IRepository _repository;
        private ApplicationDbContext _applicationDbContext;
        private List<Cloth> _cloths;
        private List<Size> _sizes;
        private List<ClothCollection> _clothCollections;
        private List<TypePerson> _typePersons;
        private Guid _buyerId;
        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BMW_Final_Project")
                .Options;

            _applicationDbContext = new ApplicationDbContext(contextOptions);
            _repository = new Repository(_applicationDbContext);

            _buyerId = Guid.Parse("c6291132-e05b-491a-84ee-1049d1f036dc");


            _sizes = new List<Size>()
            {
                new()
                {
                    Id = 1,
                }
            };
            
            _typePersons = new List<TypePerson>()
            {
                new()
                {

                },
                new()
                {

                }
            };

            _clothCollections = new List<ClothCollection>()
            {
                new()
                {

                }
            };

            _cloths = new List<Cloth>()
            {
                new()
                {
                    Id = 1
                },
                new()
                {

                },
                new()
                {

                },

            };



            _applicationDbContext.AddRange(_cloths);
            _applicationDbContext.AddRange(_sizes);
            _applicationDbContext.AddRange(_clothCollections);
            _applicationDbContext.AddRange(_typePersons);

            _applicationDbContext.SaveChanges();

            _clothService = new ClothService(_repository);
        }

        [TearDown]
        public void TearDown()
        {
            _applicationDbContext.Database.EnsureDeleted();
            _applicationDbContext.Dispose();
        }
    }
}
