using BMW_Final_Project.Engine.Contracts;
using BMW_Final_Project.Engine.Models.Motorcycle;
using BMW_Final_Project.Engine.Services;
using BMW_Final_Project.Infrastructure.Data.Common;
using BMW_Final_Project.Infrastructure.Data;
using BMW_Final_Project.Infrastructure.Data.Models.Motorcycle;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BMW_Final_Project.UnitTests
{
    [TestFixture]
    public class MotorcycleServiceTesting
    {
        private IMotorcycleService _motorcycleService;
        private IRepository _repository;
        private ApplicationDbContext _applicationDbContext;
        private List<Motorcycle> _motorcycles;
        private List<ColorCategory> _colors;
        private List<TypeMotor> _typeMotor;
        private List<StandardEuro> _standardEuros;
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

            _colors = new List<ColorCategory>()
            {
                new()
                {
                    Id = 1,
                    Name = "�����",
                    IsActive = true
                }
            };

            _typeMotor = new List<TypeMotor>()
            {
                new()
                {
                    Id = 1,
                    Name = "Sport",
                },
                 new()
                 {
                    Id = 2,
                    Name = "M",
                }
            };

            _standardEuros = new List<StandardEuro>()
            {
                new()
                {
                    Id = 1,
                    Name = "����-1",
                }
            };
            _motorcycles = new List<Motorcycle>()
            {
                new()
                {
                    Id = 1, BuyerId = _buyerId,CC = 1000, ColorCategoryId = 1,DTC = "DTC",FrontBreak = "FrontBrake",HorsePowers = 200,
                    RearBreak = "RearBrake",Model = "S1000RR",TypeMotorId = 1,StandardEuroId = 1,Kg = 200,TankCapacity = 20,
                    Price = 20000,Year = DateTime.Now.Date.AddDays(-1),Transmission = "Transmission",SeatHeightMm = 700,
                    ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",Amount = 20,IsActive = true

                },
                new()
                {
                    Id = 2, BuyerId = _buyerId,CC = 1000, ColorCategoryId = 1,DTC = "DTC",FrontBreak = "FrontBrake",HorsePowers = 220,
                    RearBreak = "RearBrake",Model = "M1000RR",TypeMotorId = 2,StandardEuroId = 1,Kg = 197,TankCapacity = 22,
                    Price = 40000,Year = DateTime.Now.Date.AddDays(-3),Transmission = "Transmission",SeatHeightMm = 600,
                    ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",Amount = 2,IsActive = true
                },
                new()
                {
                    Id = 3, BuyerId = _buyerId,CC = 1000, ColorCategoryId = 1,DTC = "DTC",FrontBreak = "FrontBrake",HorsePowers = 220,
                    RearBreak = "RearBrake",Model = "F900R",TypeMotorId = 2,StandardEuroId = 1,Kg = 197,TankCapacity = 22,
                    Price = 40000,Year = DateTime.Now.Date.AddDays(-3),Transmission = "Transmission",SeatHeightMm = 600,
                    ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",Amount = 2,IsActive = false
                },

            };



            _applicationDbContext.AddRange(_motorcycles);
            _applicationDbContext.AddRange(_colors);
            _applicationDbContext.AddRange(_standardEuros);
            _applicationDbContext.AddRange(_typeMotor);

            _applicationDbContext.SaveChanges();

            _motorcycleService = new MotorcycleService(_repository);
        }

        [TearDown]
        public void TearDown()
        {
            _applicationDbContext.Database.EnsureDeleted();
            _applicationDbContext.Dispose();
        }

        [TestCase(2)]
        public async Task GetAllMotorcyclesAsync_ShouldReturnAllMotorcycles(int expectedMotorcyclesCount)
        {
            var returnedMotorcycles = await _motorcycleService.AllAsync();

            int returnedCount = returnedMotorcycles.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedMotorcyclesCount));
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        public async Task GetAllMotorcyclesByIdTypeAsync_ShouldReturnAllMotorcyclesByThisType(int expectedMotorcyclesCount, int id)
        {
            var returnedMotorcycles = await _motorcycleService.LoadByIdAsync(id);

            int returnedCount = returnedMotorcycles.Count();

            Assert.That(returnedCount, Is.EqualTo(expectedMotorcyclesCount));
        }

        [Test]
        public async Task CreateMotorcycleAsync_ShouldCreateAndAddMotorcycle()
        {
            var model = new AddMotorcycleModel()
            {
                BuyerId = _buyerId,
                CC = 1000,
                ColorCategoryId = 1,
                DTC = "DTC",
                FrontBreak = "FrontBrake",
                HorsePowers = 220,
                RearBreak = "RearBrake",
                Model = "F800R",
                TypeMotorId = 2,
                StandardEuroId = 1,
                Kg = 197,
                TankCapacity = 22,
                Price = 40000,
                Year = DateTime.Now.Date.AddDays(-3),
                Transmission = "Transmission",
                SeatHeightMm = 600,
                ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",
                Amount = 2,
            };

            await _motorcycleService.AddAsync(model);

            var motorcyclesCountInDb = await _applicationDbContext
                .Motorcycles
                .ToListAsync();

            int expectedCountInDb = 4;
            int actualCountInDb = motorcyclesCountInDb.Count();

            var motorcycleToReturn = await _applicationDbContext
                .Motorcycles
                .FirstOrDefaultAsync(x => x.Id == 4
                                          && x.Model == "F800R");

            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
            Assert.That(motorcycleToReturn, Is.Not.Null);
        }
        [Test]
        public async Task CreateMotorcycleAsync_ShouldAddMotorcycleIfItExist()
        {
            var model = new AddMotorcycleModel()
            {
                BuyerId = _buyerId,
                CC = 1000,
                ColorCategoryId = 1,
                DTC = "DTC",
                FrontBreak = "FrontBrake",
                HorsePowers = 220,
                RearBreak = "RearBrake",
                Model = "F900R",
                TypeMotorId = 2,
                StandardEuroId = 1,
                Kg = 197,
                TankCapacity = 22,
                Price = 40000,
                Year = DateTime.Now.Date.AddDays(-3),
                Transmission = "Transmission",
                SeatHeightMm = 600,
                ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",
                Amount = 2,
            };

            await _motorcycleService.AddAsync(model);

            var motorcyclesCountInDb = await _applicationDbContext
                .Motorcycles
                .ToListAsync();

            int expectedCountInDb = 3;
            int actualCountInDb = motorcyclesCountInDb.Count();

            var motorcycleToReturn = await _applicationDbContext
                .Motorcycles
                .FirstOrDefaultAsync(x => x.Id == 3
                                          && x.Model == "F900R");

            Assert.That(motorcycleToReturn.IsActive, Is.True);
            Assert.That(actualCountInDb, Is.EqualTo(expectedCountInDb));
            Assert.That(motorcycleToReturn, Is.Not.Null);
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 1, 1, 19)]
        public async Task AddMotorcycleToAllMineMotorcycles_ShouldAddMotorcycleIfItIsNotAdded(string userId, int motorcycleId, int expectedCount, int expectedAmount)
        {
            await _motorcycleService.AddAsync(motorcycleId, Guid.Parse(userId));

            var actualCount = await _applicationDbContext
                .MotorcyclesBuyers
                .CountAsync(x => x.BuyerId == Guid.Parse(userId));

            var motorcycleWitchTheUserAdded = await _applicationDbContext.Motorcycles
                .FirstOrDefaultAsync(x => x.Id == motorcycleId);

            var actualAmount = motorcycleWitchTheUserAdded?.Amount;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualAmount, Is.EqualTo(expectedAmount));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 12)]
        public async Task AddMotorcycleToAllMineMotorcycles_ShouldThrowException(string userId, int motorcycleId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _motorcycleService.AddAsync(motorcycleId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddMotorcycleToAllMineMotorcycles_ShouldThrowArgumentExceptionBecauseOfAddingTwoTimes(string userId, int motorcycleId)
        {
            await _motorcycleService.AddAsync(motorcycleId, Guid.Parse(userId));

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _motorcycleService.AddAsync(motorcycleId, Guid.Parse(userId)));
        }

        [TestCase("c8295132-e05b-491a-84ee-1049d1f036dc", 2)]
        public async Task AddMotorcycleToAllMineMotorcycles_ShouldThrowArgumentExceptionBecauseOfAmount(string userId, int motorcycleId)
        {
            var motorcycle = await _motorcycleService.GetByIdAsync(motorcycleId);

            motorcycle.Amount = 0;

            Assert.ThrowsAsync<ArgumentException>(async ()
                => await _motorcycleService.AddAsync(motorcycleId, Guid.Parse(userId)));
        }
        [TestCase(8)]
        [TestCase(9)]
        public async Task GetById_shouldThrowNullReferenceException(int motorcycleId)
        {
            Assert.ThrowsAsync<ArgumentNullException>(async ()
                => await _motorcycleService.GetByIdAsync(motorcycleId));
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetById_shouldReturnTheMotorcycle(int motorcycleId)
        {
            Assert.IsNotNull(await _motorcycleService.GetByIdAsync(motorcycleId));

            var returned = await _motorcycleService.GetByIdAsync(motorcycleId);

            var expected = await _applicationDbContext
                .Motorcycles
                .Select(x => new AddMotorcycleModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Model = x.Model,
                    Amount = x.Amount,
                    TankCapacity = x.TankCapacity,
                    CC = x.CC,
                    DTC = x.DTC,
                    FrontBreak = x.FrontBreak,
                    Transmission = x.Transmission,
                    StandardEuroId = x.StandardEuroId,
                    SeatHeightMm = x.SeatHeightMm,
                    RearBreak = x.RearBreak,
                    HorsePowers = x.HorsePowers,
                    Kg = x.Kg,
                    ColorCategoryId = x.ColorCategoryId,
                    Year = x.Year
                })
                .FirstAsync(x => x.Id == motorcycleId);

            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImageUrl, Is.EqualTo(expected.ImageUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Model, Is.EqualTo(expected.Model));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.Year, Is.EqualTo(expected.Year));
            Assert.That(returned.Kg, Is.EqualTo(expected.Kg));
            Assert.That(returned.HorsePowers, Is.EqualTo(expected.HorsePowers));
            Assert.That(returned.RearBreak, Is.EqualTo(expected.RearBreak));
            Assert.That(returned.SeatHeightMm, Is.EqualTo(expected.SeatHeightMm));
            Assert.That(returned.StandardEuroId, Is.EqualTo(expected.StandardEuroId));
            Assert.That(returned.Transmission, Is.EqualTo(expected.Transmission));
            Assert.That(returned.FrontBreak, Is.EqualTo(expected.FrontBreak));
            Assert.That(returned.DTC, Is.EqualTo(expected.DTC));
            Assert.That(returned.CC, Is.EqualTo(expected.CC));
            Assert.That(returned.TankCapacity, Is.EqualTo(expected.TankCapacity));


        }

        [TestCase(1)]
        public async Task EditAsync_shouldReturnTheMotorcycleEddited(int motorcycleId)
        {
            var model = new EditMotorcycleModel()
            {
                Id = 1,
                CC = 1200,
                ColorCategoryId = 1,
                DTC = "DTC",
                FrontBreak = "FrontBrake",
                HorsePowers = 220,
                RearBreak = "RearBrake",
                Model = "F800R",
                TypeMotorId = 2,
                StandardEuroId = 1,
                Kg = 127,
                TankCapacity = 22,
                Price = 40000,
                Year = DateTime.Now.Date.AddDays(-3),
                Transmission = "Transmission",
                SeatHeightMm = 600,
                ImageUrl = "https://images4.alphacoders.com/127/1277784.jpg",
                Amount = 22,
            };

            await _motorcycleService.EditAsync(model);

            var returned = await _motorcycleService.GetByIdAsync(motorcycleId);

            var expected = await _applicationDbContext
                .Motorcycles
                .Select(x => new AddMotorcycleModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Model = x.Model,
                    Amount = x.Amount,
                    TankCapacity = x.TankCapacity,
                    CC = x.CC,
                    DTC = x.DTC,
                    FrontBreak = x.FrontBreak,
                    Transmission = x.Transmission,
                    StandardEuroId = x.StandardEuroId,
                    SeatHeightMm = x.SeatHeightMm,
                    RearBreak = x.RearBreak,
                    HorsePowers = x.HorsePowers,
                    Kg = x.Kg,
                    ColorCategoryId = x.ColorCategoryId,
                    Year = x.Year
                })
                .FirstAsync(x => x.Id == motorcycleId);


            Assert.That(returned, Is.Not.Null);
            Assert.That(returned.Id, Is.EqualTo(expected.Id));
            Assert.That(returned.ImageUrl, Is.EqualTo(expected.ImageUrl));
            Assert.That(returned.Price, Is.EqualTo(expected.Price));
            Assert.That(returned.Model, Is.EqualTo(expected.Model));
            Assert.That(returned.Amount, Is.EqualTo(expected.Amount));
            Assert.That(returned.Year, Is.EqualTo(expected.Year));
            Assert.That(returned.Kg, Is.EqualTo(expected.Kg));
            Assert.That(returned.HorsePowers, Is.EqualTo(expected.HorsePowers));
            Assert.That(returned.RearBreak, Is.EqualTo(expected.RearBreak));
            Assert.That(returned.SeatHeightMm, Is.EqualTo(expected.SeatHeightMm));
            Assert.That(returned.StandardEuroId, Is.EqualTo(expected.StandardEuroId));
            Assert.That(returned.Transmission, Is.EqualTo(expected.Transmission));
            Assert.That(returned.FrontBreak, Is.EqualTo(expected.FrontBreak));
            Assert.That(returned.DTC, Is.EqualTo(expected.DTC));
            Assert.That(returned.CC, Is.EqualTo(expected.CC));
            Assert.That(returned.TankCapacity, Is.EqualTo(expected.TankCapacity));
            Assert.That(returned.Id, Is.EqualTo(expected.Id));

        }

        [Test]
        public async Task DeleteMotorcycleAsync_ShouldSetIsActiveToFalse()
        {
            var motor = await _motorcycleService.GetByIdAsync(1);

            await _motorcycleService.DeleteAsync(1);

            Assert.IsFalse(motor.IsActive);
            Assert.That(motor, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task DetailsMotorcycleAsync_ShouldReturnTheMotorcycleWithTheCorrectId(int motorcycleId)
        {
            var motor = await _motorcycleService.DetailsAsync(motorcycleId);

            Assert.That(motor.Id, Is.EqualTo(motorcycleId));
            Assert.That(motor,Is.Not.Null);
        }

        [TestCase(12)]
        public async Task DetailsMotorcycleAsync_ShouldReturnExceptionBecauseOfNull(int motorcycleId)
        {
            Assert.ThrowsAsync<NullReferenceException>(async ()
                => await _motorcycleService.DetailsAsync(motorcycleId));
        }

        [TestCase(2)]
        public async Task GetTypes_ShouldReturnTheTypesOfTheMotorcycle(int expectedCount)
        {
            var model = await _motorcycleService.GetTypeMotorcyclesAsync();

            int actualCount = model.Count;

            Assert.That(actualCount,Is.EqualTo(expectedCount));
        }
        [TestCase(1)]
        public async Task GetColors_ShouldReturnTheColorsOfTheMotorcycle(int expectedCount)
        {
            var model = await _motorcycleService.GetColorsAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
        [TestCase(1)]
        public async Task GetEuros_ShouldReturnTheEurosOfTheMotorcycle(int expectedCount)
        {
            var model = await _motorcycleService.GetStandardEurosAsync();

            int actualCount = model.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

    }
}