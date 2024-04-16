using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Accessories;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Engine.Services;
using BMW_Final_Project.Infrastructure.Data;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data.Models.Accessories;
using Microsoft.EntityFrameworkCore;

namespace BMW_Final_Project.UnitTests
{
    [TestFixture]
    public class AccessoriesServiceTesting
    {
        private IAccessoriesService _accessoriesService;
        private IRepository _repository;
        private ApplicationDbContext _applicationDbContext;
        private List<Accessor> _accessors;
        private List<ItemType> _itemTypes;
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

            _itemTypes = new List<ItemType>()
            {
                new()
                {
                    Id = 1,
                    Name = "електронни",
                }, new()
                {
                    Id = 2,
                    Name = "Детски",
                }
            };


            _accessors = new List<Accessor>()
            {
                new()
                {
                    Id = 1, BuyerId = _buyerId,IsActive = true, Amount = 20,ItemTypeId = 2,
                    ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                    Name = "BlackAccsesoar",Price = 200

                },
                new()
                {
                    Id = 2, BuyerId = _buyerId,IsActive = true, Amount = 20,ItemTypeId = 1,
                    ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                    Name = "BlackAccsesoar2",Price = 200
                },
                new()
                {
                    Id = 3, BuyerId = _buyerId, IsActive = false, Amount = 20,ItemTypeId = 1,
                    ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                    Name = "BlackAccsesoar3",Price = 200
                },

            };


            _applicationDbContext.AddRange(_itemTypes);
            _applicationDbContext.AddRange(_accessors);


            _applicationDbContext.SaveChanges();

            _accessoriesService = new AccessoriesService(_repository);
        }

        [TearDown]
        public void TearDown()
        {
            _applicationDbContext.Database.EnsureDeleted();
            _applicationDbContext.Dispose();
        }

        [TestCase(2)]
        public async Task GetAllAccessoriesAsync_ShouldReturnAllMotorcycles(int expectedAccessoriesCount)
        {
            var returnedAccessories = await _accessoriesService.AllAccessoriesAsync();

            int returnedCount = returnedAccessories.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedAccessoriesCount));
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        public async Task GetAllAccessoriesByIdTypeAsync_ShouldReturnAllAccessoriesByThisType(int expectedAccessoriesCount, int id)
        {
            var returnedAccessories = await _accessoriesService.LoadByIdAsync(id);

            int returnedCount = returnedAccessories.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedAccessoriesCount));
        }

        [Test]
        public async Task CreateAccessorAsync_ShouldCreateAndAddAccessor()
        {
            var model = new AddAccsessoarModel()
            {
                BuyerId = _buyerId,
                Price = 40000,
                Amount = 2,
                Name = "MyAccessor",
                ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                ItemTypeId = 1,
            };

            await _accessoriesService.AddAsync(model);

            var accessorCountInDb = await _applicationDbContext
                .Accessors
                .ToListAsync();

            int expectedCountInDb = 4;
            int actualCountInDb = accessorCountInDb.Count();

            var accessorToReturn = await _applicationDbContext
                .Accessors
                .FirstOrDefaultAsync(x => x.Id == 4
                                          && x.Name == "MyAccessor");

            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
            Assert.That(accessorCountInDb, Is.Not.Null);
        }
        [Test]
        public async Task CreateAccessorAsync_ShouldAddAccessorIfItExist()
        {
            var model = new AddAccsessoarModel()
            {
                BuyerId = _buyerId,
                Price = 40000,
                Amount = 2,
                Name = "BlackAccsesoar3",
                ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                ItemTypeId = 1,
            };

            await _accessoriesService.AddAsync(model);

            var accessorsCountInDb = await _applicationDbContext
                .Accessors
                .ToListAsync();

            int expectedCountInDb = 3;
            int actualCountInDb = accessorsCountInDb.Count();

            var accessorsToReturn = await _applicationDbContext
                .Accessors
                .FirstOrDefaultAsync(x => x.Id == 3
                                          && x.Name == "BlackAccsesoar3");

            Assert.That(accessorsToReturn, Is.Not.Null);
            Assert.That(accessorsToReturn.IsActive, Is.True);
            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 1, 1, 19)]
        public async Task AddAccessorToAllMineAccessors_ShouldAddAccessorIfItIsNotAdded(string userId, int accessorId, int expectedCount, int expectedAmount)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            var actualCount = await _applicationDbContext
                .AccessorsBuyers
                .CountAsync(x => x.BuyerId == Guid.Parse(userId));

            var accessorWitchTheUserAdded = await _applicationDbContext.Accessors
                .FirstOrDefaultAsync(x => x.Id == accessorId);

            var actualAmount = accessorWitchTheUserAdded?.Amount;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 12)]
        public async Task AddAccessorToAllMineAccessors_ShouldThrowException(string userId, int accessorId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddAccessorToAllMineAccessors_ShouldThrowArgumentExceptionBecauseOfAddingTwoTimes(string userId, int accessorId)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddAccessorToAllMineAccessors_ShouldThrowArgumentExceptionBecauseOfAmount(string userId, int accessorId)
        {
            var motorcycle = await _accessoriesService.GetByIdAsync(accessorId);

            motorcycle.Amount = 0;

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId)));
        }

        [TestCase(8)]
        [TestCase(9)]
        public async Task GetById_shouldThrowNullReferenceException(int accessorId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _accessoriesService.GetByIdAsync(accessorId));
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetById_shouldReturnTheAccessor(int accessorId)
        {
            Assert.IsNotNull(await _accessoriesService.GetByIdAsync(accessorId));

            var returned = await _accessoriesService.GetByIdAsync(accessorId);

            var expected = await _applicationDbContext
                .Accessors
                .Select(x => new AddAccsessoarModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    Name = x.Name,
                    Amount = x.Amount,
                    ItemTypeId = x.ItemTypeId,
                })
                .FirstAsync(x => x.Id == accessorId);

            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImgUrl, Is.EqualTo(expected.ImgUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Name, Is.EqualTo(expected.Name));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.ItemTypeId, Is.EqualTo(expected.ItemTypeId));
        }

        [TestCase(2)]
        public async Task GetItemTypes_ShouldReturnTheTypesOfTheAccessor(int expectedCount)
        {
            var model = await _accessoriesService.GetItemTypeModelAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task IsThisAccsesoarExistAsync_ShouldReturnTrue()
        {
            var accessor = await _accessoriesService.GetByIdAsync(1);

            var model = new AddAccsessoarModel()
            {
                Id = accessor.Id,
                Name = accessor.Name,
                IsActive = accessor.IsActive
            };

            Assert.IsTrue(await _accessoriesService.IsThisAccsesoarExistAsync(model));
        }
        [Test]
        public async Task IsThisAccsesoarExistAsync_ShouldReturnFalse()
        {
            var model = new AddAccsessoarModel()
            {
                Name = "S100FR",
                IsActive = true,
            };

            Assert.IsFalse(await _accessoriesService.IsThisAccsesoarExistAsync(model));

            var model2 = new AddAccsessoarModel()
            {
                Name = "S1000RR",
                IsActive = false,
            };

            Assert.IsFalse(await _accessoriesService.IsThisAccsesoarExistAsync(model));
        }

        [Test]
        public async Task IsThisAccsesoarEditExistAsync_ShouldReturnTrue()
        {
            var motor = await _accessoriesService.GetByIdAsync(1);

            var model = new EditAccsesoarModel()
            {
                Id = motor.Id,
                Name = motor.Name,
            };

            Assert.IsTrue(await _accessoriesService.IsThisAccsesoarExistWhenEditAsync(model));
        }
        [Test]
        public async Task IsThisAccsesoarEditExistAsync_ShouldReturnFalse()
        {
            var model = new EditAccsesoarModel()
            {
                Name = "S100FR",
            };

            Assert.IsFalse(await _accessoriesService.IsThisAccsesoarExistWhenEditAsync(model));


            var model2 = new EditAccsesoarModel()
            {
                Name = "F900R",
            };

            Assert.IsFalse(await _accessoriesService.IsThisAccsesoarExistWhenEditAsync(model));

        }

        [TestCase(1)]
        public async Task EditAsync_shouldReturnTheAccsesoarEdited(int accessorId)
        {
            var model = new EditAccsesoarModel()
            {
                Id = 1,
                Price = 40000,
                Amount = 22,
                ImgUrl = "https://www.donbaron.bg/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/c/h/chanta-bmw-motorsport1_2_.jpg",
                ItemTypeId = 1,
                Name = "Edited"
            };

            await _accessoriesService.EditAsync(model);

            var returned = await _accessoriesService.GetByIdAsync(accessorId);

            var expected = await _applicationDbContext
                .Accessors
                .Select(x => new AddAccsessoarModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    Name = x.Name,
                    Amount = x.Amount,
                    ItemTypeId = x.ItemTypeId
                })
                .FirstAsync(x => x.Id == accessorId);


            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImgUrl, Is.EqualTo(expected.ImgUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Name, Is.EqualTo(expected.Name));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.ItemTypeId, Is.EqualTo(expected.ItemTypeId));
        }

        [Test]
        public async Task DeleteAccsesoarAsync_ShouldSetIsActiveToFalse()
        {
            var motor = await _accessoriesService.GetByIdAsync(1);

            await _accessoriesService.DeleteAsync(1);

            Assert.IsFalse(motor.IsActive);
            Assert.That(motor, Is.Not.Null);
        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 1)]
        public async Task AllMineAccsesoaries_ShouldReturnCorrectCount(int expectedCount, string userId, int accessorId)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            var model = await _accessoriesService.GetAllMineAccsesoariesAsync(Guid.Parse(userId));

            int count = model.Count;

            Assert.That(count, Is.EqualTo(expectedCount));

        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        [TestCase(2, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        public async Task RemoveAccsesoar_ShouldRemoveTheAccsesoarFromTheCollectionOnTheUser(int accessorId, string userId, int expectedCount)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            await _accessoriesService.RemoveAccsesoarAsync(accessorId);

            var model = await _accessoriesService.GetAllMineAccsesoariesAsync(Guid.Parse(userId));

            int count = model.Count;

            var modelToCheckTheAmount = await _accessoriesService.GetByIdAsync(accessorId);

            var expectedAmount = await _applicationDbContext
                .Accessors
                .Where(x => x.Id == accessorId)
                .FirstOrDefaultAsync();


            Assert.That(modelToCheckTheAmount,Is.Not.Null);
            Assert.That(expectedAmount, Is.Not.Null);
            Assert.That(count, Is.EqualTo(expectedCount));
            Assert.That(modelToCheckTheAmount.Amount, Is.EqualTo(expectedAmount.Amount));
        }

        [TestCase(11)]
        [TestCase(12)]
        public async Task RemoveAccsesoar_ShouldReturnArgumentNullException(int accessorId)
        {
            async Task Act() => await _accessoriesService.RemoveAccsesoarAsync(accessorId);

            Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        [TestCase(2, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        public async Task BuyAccsesoar_ShouldRemoveItFromTheCollectionLikeItWasForced(int accessorId, string userId, int expectedCount)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            await _accessoriesService.BuyAccsesoarAsync(accessorId);

            var model = await _accessoriesService.GetAllMineAccsesoariesAsync(Guid.Parse(userId));

            var expectedAmount = await _applicationDbContext
                .Accessors
                .Where(x => x.Id == accessorId)
                .FirstOrDefaultAsync();

            int count = model.Count;

            var modelToCheckTheAmount = await _accessoriesService.GetByIdAsync(accessorId);

            Assert.That(modelToCheckTheAmount, Is.Not.Null);
            Assert.That(expectedAmount, Is.Not.Null);
            Assert.That(count, Is.EqualTo(expectedCount));
            Assert.That(modelToCheckTheAmount.Amount, Is.EqualTo(expectedAmount.Amount));


        }
        [TestCase(11)]
        [TestCase(22)]
        public async Task BuyAccsesoar_ShouldReturnException(int accessorId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _accessoriesService.BuyAccsesoarAsync(accessorId));
        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc")]
        public async Task IsThisAccsesoarIsAddedAsync_ShouldReturnTrue(int accessorId, string userId)
        {
            await _accessoriesService.AddAsync(accessorId, Guid.Parse(userId));

            Assert.IsTrue(await _accessoriesService
                .IsThisProductIsAddedFromThisUserAsync(Guid.Parse(userId), accessorId));
        }
        [TestCase(4, "c8295132-e05b-491a-84ee-1049d1f036dc")]
        public async Task IsThisAccsesoarIsAddedAsync_ShouldReturnFalse(int accessorId, string userId)
        {
            Assert.IsFalse(await _accessoriesService
                .IsThisProductIsAddedFromThisUserAsync(Guid.Parse(userId), accessorId));
        }


    }
}
