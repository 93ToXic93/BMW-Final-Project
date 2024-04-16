using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Cloth;
using BMW_Final_Project.Engine.Models.Motorcycle;
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
                    Id = 1,Name = "S"
                }
                ,new ()
                {
                    Id = 2,Name = "XS"
                }
            };

            _typePersons = new List<TypePerson>()
            {
                new()
                {
                    Id = 1,Name = "Мъж"
                },
                new()
                {
                    Id = 2,Name = "Жена"
                }
            };

            _clothCollections = new List<ClothCollection>()
            {
                new()
                {
                    Id = 1,Name = "Лятна Колекция"
                }
            };

            _cloths = new List<Cloth>()
            {
                new()
                {
                    Id = 1,
                    BuyerId = _buyerId, Amount = 20, ClothCollectionId = 1,Description = "Noting",
                    ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                    SizeId = 2,TypePersonId = 1,Price = 200,Name = "Bmw-T-shirt",IsActive = true
                },
                new()
                {
                    Id = 2,
                    BuyerId = _buyerId, Amount = 20, ClothCollectionId = 1,Description = "Noting",
                    ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                    SizeId = 1,TypePersonId = 2,Price = 200,Name = "Bmw-T-shirt2",IsActive = true
                },
                new()
                {
                    Id = 3,
                    BuyerId = _buyerId, Amount = 20, ClothCollectionId = 1,Description = "Noting",
                    ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                    SizeId = 2,TypePersonId = 1,Price = 200,Name = "Bmw-T-shirt3",IsActive = false
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

        [TestCase(2)]
        public async Task GetAllMotorcyclesAsync_ShouldReturnAllMotorcycles(int expectedClothCount)
        {
            var returnedCloths = await _clothService.AllAsync();

            int returnedCount = returnedCloths.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedClothCount));
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        public async Task GetAllMotorcyclesByIdTypeAsync_ShouldReturnAllMotorcyclesByThisType(int expectedClothCount, int id)
        {
            var returnedCloths = await _clothService.LoadByIdAsync(id);

            int returnedCount = returnedCloths.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedClothCount));
        }

        [Test]
        public async Task CreateClothAsync_ShouldCreateAndAddCloth()
        {
            var model = new AddClothModel()
            {
                BuyerId = _buyerId,
                Amount = 20,
                ClothCollectionId = 1,
                Description = "Noting",
                ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                SizeId = 1,
                TypePersonId = 2,
                Price = 200,
                Name = "Bmw-T-shirt24",
            };

            await _clothService.AddAsync(model);

            var clothCountInDb = await _applicationDbContext
                .Cloths
                .ToListAsync();

            int expectedCountInDb = 4;
            int actualCountInDb = clothCountInDb.Count();

            var clothToReturn = await _applicationDbContext
                .Cloths
                .FirstOrDefaultAsync(x => x.Id == 4
                                          && x.Name == "Bmw-T-shirt24");

            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
            Assert.That(clothToReturn, Is.Not.Null);
        }

        [Test]
        public async Task CreateClothAsync_ShouldAddClothIfItExist()
        {
            var model = new AddClothModel()
            {
                BuyerId = _buyerId,
                Amount = 22,
                ClothCollectionId = 1,
                Description = "Noting",
                ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                SizeId = 1,
                TypePersonId = 2,
                Price = 200,
                Name = "Bmw-T-shirt3",
            };

            await _clothService.AddAsync(model);

            var clothsCountInDb = await _applicationDbContext
                .Cloths
                .ToListAsync();

            int expectedCountInDb = 3;
            int actualCountInDb = clothsCountInDb.Count();

            var motorcycleToReturn = await _applicationDbContext
                .Cloths
                .FirstOrDefaultAsync(x => x.Id == 3
                                          && x.Name == "Bmw-T-shirt3");

            Assert.That(motorcycleToReturn, Is.Not.Null);
            Assert.That(motorcycleToReturn.IsActive, Is.True);
            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 1, 1, 19)]
        public async Task AddClothToAllMineCloths_ShouldAddMotorcycleIfItIsNotAdded(string userId, int clothId, int expectedCount, int expectedAmount)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            var actualCount = await _applicationDbContext
                .ClothsBuyers
                .CountAsync(x => x.BuyerId == Guid.Parse(userId));

            var clothWitchTheUserAdded = await _applicationDbContext.Cloths
                .FirstOrDefaultAsync(x => x.Id == clothId);

            var actualAmount = clothWitchTheUserAdded?.Amount;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 12)]
        public async Task AddClothToAllMineCloths_ShouldThrowException(string userId, int clothId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _clothService.AddAsync(clothId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddClothToAllMineCloths_ShouldThrowArgumentExceptionBecauseOfAddingTwoTimes(string userId, int clothId)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _clothService.AddAsync(clothId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddClothToAllMineCloths_ShouldThrowArgumentExceptionBecauseOfAmount(string userId, int clothId)
        {
            var motorcycle = await _clothService.GetByIdAsync(clothId);

            motorcycle.Amount = 0;

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _clothService.AddAsync(clothId, Guid.Parse(userId)));
        }

        [TestCase(8)]
        [TestCase(9)]
        public async Task GetById_shouldThrowNullReferenceException(int clothId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _clothService.GetByIdAsync(clothId));
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetById_shouldReturnTheCloth(int clothId)
        {
            Assert.IsNotNull(await _clothService.GetByIdAsync(clothId));

            var returned = await _clothService.GetByIdAsync(clothId);

            var expected = await _applicationDbContext
                .Cloths
                .Select(x => new AddClothModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    Name = x.Name,
                    Amount = x.Amount,
                    TypePersonId = x.TypePersonId,
                    SizeId = x.SizeId,
                    ClothCollectionId = x.ClothCollectionId,
                    Description = x.Description,
                    BuyerId = x.BuyerId,
                    IsActive = x.IsActive
                })
                .FirstAsync(x => x.Id == clothId);

            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImgUrl, Is.EqualTo(expected.ImgUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Name, Is.EqualTo(expected.Name));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.Description, Is.EqualTo(expected.Description));
            Assert.That(returned.BuyerId, Is.EqualTo(expected.BuyerId));
            Assert.That(returned.ClothCollectionId, Is.EqualTo(expected.ClothCollectionId));
            Assert.That(returned.SizeId, Is.EqualTo(expected.SizeId));
            Assert.That(returned.TypePersonId, Is.EqualTo(expected.TypePersonId));
            Assert.That(returned.IsActive, Is.EqualTo(expected.IsActive));
        }

        [TestCase(1)]
        public async Task EditAsync_shouldReturnTheClothEdited(int clothId)
        {
            var model = new EditClothModel()
            {
                Id = 1,
                Price = 40000,
                Amount = 26,
                Description = "NotingSpecial",
                ClothCollectionId = 1,
                SizeId = 1,
                TypePersonId = 2,
                ImgUrl = "https://bmwaccessories.ie/cdn/shop/products/80145A21737_3.jpg?v=1647336616&width=1445",
                Name = "BmwT"
            }; 

            await _clothService.EditAsync(model);

            var returned = await _clothService.GetByIdAsync(clothId);

            var expected = await _applicationDbContext
                .Cloths
                .Select(x => new EditClothModel()
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Price = x.Price,
                    Name = x.Name,
                    Amount = x.Amount,
                    Description = x.Description,
                    ClothCollectionId = x.ClothCollectionId,
                    SizeId = x.SizeId,
                    TypePersonId = x.TypePersonId,
                })
                .FirstAsync(x => x.Id == clothId);


            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImgUrl, Is.EqualTo(expected.ImgUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Name, Is.EqualTo(expected.Name));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.Description, Is.EqualTo(expected.Description));
            Assert.That(returned.ClothCollectionId, Is.EqualTo(expected.ClothCollectionId));
            Assert.That(returned.SizeId, Is.EqualTo(expected.SizeId));
            Assert.That(returned.TypePersonId, Is.EqualTo(expected.TypePersonId));

        }

        [Test]
        public async Task DeleteClothAsync_ShouldSetIsActiveToFalse()
        {
            var cloth = await _clothService.GetByIdAsync(1);

            await _clothService.DeleteAsync(1);

            Assert.IsFalse(cloth.IsActive);
            Assert.That(cloth, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task DetailsClothAsync_ShouldReturnTheClothWithTheCorrectId(int clothId)
        {
            var motor = await _clothService.DetailsAsync(clothId);

            Assert.That(motor.Id, Is.EqualTo(clothId));
            Assert.That(motor, Is.Not.Null);
        }

        [TestCase(12)]
        public async Task DetailsClothAsync_ShouldReturnExceptionBecauseOfNull(int clothId)
        {
            Assert.ThrowsAsync<NullReferenceException>(async ()
                => await _clothService.DetailsAsync(clothId));
        }

        [TestCase(2)]
        public async Task GetTypes_ShouldReturnTheTypesOfTheCloth(int expectedCount)
        {
            var model = await _clothService.GetTypesAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [TestCase(1)]
        public async Task GetClothCollectionsAsync_ShouldReturnTheCollectionsOfTheCloth(int expectedCount)
        {
            var model = await _clothService.GetClothCollectionsAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [TestCase(2)]
        public async Task GetSizesAsync_ShouldReturnTheSizesOfTheCloth(int expectedCount)
        {
            var model = await _clothService.GetSizesAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task IsThisClothExistAsync_ShouldReturnTrue()
        {
            var motor = await _clothService.GetByIdAsync(1);

            var model = new AddClothModel()
            {
                Id = motor.Id,
                Name = motor.Name,
                IsActive = motor.IsActive
            };

            Assert.IsTrue(await _clothService.IsThisClothExistAsync(model));
        }
        [Test]
        public async Task IsThisClothExistAsync_ShouldReturnFalse()
        {
            var model = new AddClothModel()
            {
                Name = "S100FR",
                IsActive = true,
            };

            Assert.IsFalse(await _clothService.IsThisClothExistAsync(model));

            var model2 = new AddClothModel()
            {
                Name = "S1000RR",
                IsActive = false,
            };

            Assert.IsFalse(await _clothService.IsThisClothExistAsync(model));
        }

        [Test]
        public async Task IsThisClothExistWhenEditAsync_ShouldReturnTrue()
        {
            var motor = await _clothService.GetByIdAsync(1);

            var model = new EditClothModel()
            {
                Id = motor.Id,
                Name = motor.Name,
            };

            Assert.IsTrue(await _clothService.IsThisClothExistWhenEditAsync(model));
        }
        [Test]
        public async Task IsThisClothExistWhenEditAsync_ShouldReturnFalse()
        {
            var model = new EditClothModel()
            {
                Name = "S100FR",
            };

            Assert.IsFalse(await _clothService.IsThisClothExistWhenEditAsync(model));

            var model2 = new EditClothModel()
            {
                Name = "F900R",
            };

            Assert.IsFalse(await _clothService.IsThisClothExistWhenEditAsync(model));
        }


        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 1)]
        public async Task AllMineCloths_ShouldReturnCorrectCount(int expectedCount, string userId, int clothId)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            var model = await _clothService.GetAllMineClothsAsync(Guid.Parse(userId));

            int count = model.Count;

            Assert.That(count, Is.EqualTo(expectedCount));

        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        [TestCase(2, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        public async Task RemoveCloth_ShouldRemoveTheClothFromTheCollectionOnTheUser(int clothId, string userId, int expectedCount)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            await _clothService.RemoveClothAsync(clothId);

            var model = await _clothService.GetAllMineClothsAsync(Guid.Parse(userId));

            int count = model.Count;

            var modelToCheckTheAmount = await _clothService.GetByIdAsync(clothId);

            var expectedAmount = await _applicationDbContext
                .Cloths
                .Where(x => x.Id == clothId)
                .FirstOrDefaultAsync();

            Assert.That(modelToCheckTheAmount,Is.Not.Null);
            Assert.That(expectedAmount, Is.Not.Null);
            Assert.That(count, Is.EqualTo(expectedCount));
            Assert.That(modelToCheckTheAmount.Amount, Is.EqualTo(expectedAmount.Amount));
        }

        [TestCase(11)]
        [TestCase(12)]
        public async Task RemoveCloth_ShouldReturnArgumentNullException(int clothId)
        {
            async Task Act() => await _clothService.RemoveClothAsync(clothId);

            Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        [TestCase(2, "c8295132-e05b-491a-84ee-1049d1f036dc", 0)]
        public async Task BuyCloth_ShouldRemoveItFromTheCollectionLikeItWasForced(int clothId, string userId, int expectedCount)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            await _clothService.BuyClothAsync(clothId);

            var model = await _clothService.GetAllMineClothsAsync(Guid.Parse(userId));

            var expectedAmount = await _applicationDbContext
                .Cloths
                .Where(x => x.Id == clothId)
                .FirstOrDefaultAsync();

            int count = model.Count;

            var modelToCheckTheAmount = await _clothService.GetByIdAsync(clothId);

            Assert.That(modelToCheckTheAmount, Is.Not.Null);
            Assert.That(expectedAmount, Is.Not.Null);
            Assert.That(count, Is.EqualTo(expectedCount));
            Assert.That(modelToCheckTheAmount.Amount, Is.EqualTo(expectedAmount.Amount));


        }
        [TestCase(11)]
        [TestCase(22)]
        public async Task BuyCloth_ShouldReturnException(int clothId)
        {
            async Task Act() => await _clothService.BuyClothAsync(clothId);

            Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [TestCase(1, "c8295132-e05b-491a-84ee-1049d1f036dc")]
        public async Task IsThisClothIsAddedAsync_ShouldReturnTrue(int clothId, string userId)
        {
            await _clothService.AddAsync(clothId, Guid.Parse(userId));

            Assert.IsTrue(await _clothService
                .IsThisProductIsAddedAsync(Guid.Parse(userId), clothId));
        }
        [TestCase(4, "c8295132-e05b-491a-84ee-1049d1f036dc")]
        public async Task IsThisClothIsAddedAsync_ShouldReturnFalse(int clothId, string userId)
        {
            Assert.IsFalse(await _clothService
                .IsThisProductIsAddedAsync(Guid.Parse(userId), clothId));
        }

    }
}
