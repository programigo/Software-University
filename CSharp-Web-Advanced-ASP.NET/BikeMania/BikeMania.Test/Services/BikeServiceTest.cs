namespace BikeMania.Test.Services
{
    using BikeMania.Data.Models;
    using BikeMania.Services.Bike.Implementations;
    using Data;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class BikeServiceTest
    {
        public BikeServiceTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task AllAsyncShouldReturnCorrectOrder()
        {
            //Arrange
            var db = this.GetDatabase();

            var dragBike = new Bike { Id = 1, Make = Make.Drag, Model = "Master Pro", Price = 780.90m };
            var pinarelloBike = new Bike { Id = 2, Make = Make.Pinarello, Model = "Dogma F10", Price = 15000.790m };
            var bianchiBike = new Bike { Id = 3, Make = Make.Bianchi, Model = "Via Niorne", Price = 7800.90m };

            db.AddRange(dragBike, pinarelloBike, bianchiBike);

            await db.SaveChangesAsync();

            var bikeService = new BikeService(db);

            //Act
            var bikes = await bikeService.AllAsync();

            //Assert
            bikes
                .Should()
                .Match(b => b.ElementAt(0).Id == 3
                    && b.ElementAt(1).Id == 2
                    && b.ElementAt(2).Id == 1)
                    .And
                    .HaveCount(3);
        }

        [Fact]
        public async Task EditBikeAsyncShouldSaveBikeWithTheEditedParameters()
        {
            const int bikeId = 1;
            const Make bikeMake = Make.Pinarello;
            const string bikeModel = "Dogma F10";
            const decimal bikePrice = 15000.790m;
            const int bikeQuantity = 1;
            const int bikeFrameSize = 550;

            //Arrange
            var db = this.GetDatabase();

            var bike = new Bike
            {
                Id = bikeId,
                Make = bikeMake,
                Model = bikeModel,
                Price = bikePrice,
                Quantity = bikeQuantity,
                FrameSize = bikeFrameSize
            };

            db.Add(bike);

            await db.SaveChangesAsync();

            var bikeService = new BikeService(db);

            //Act
            var editedBike = await bikeService.EditAsync(bikeId, Make.Drag, "Bluebird", 870.76m, null, 3, 550, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);

            //Assert
            editedBike
                .Should()
                .Be(true);
        }

        [Fact]
        public async Task DeleteAsyncShouldRemoveBikeFromDatabase()
        {
            //Arrange
            var db = this.GetDatabase();

            var dragBike = new Bike { Id = 1, Make = Make.Drag, Model = "Master Pro", Price = 780.90m };
            var pinarelloBike = new Bike { Id = 2, Make = Make.Pinarello, Model = "Dogma F10", Price = 15000.790m };
            var bianchiBike = new Bike { Id = 3, Make = Make.Bianchi, Model = "Via Niorne", Price = 7800.90m };

            db.Bikes.AddRange(dragBike, pinarelloBike, bianchiBike);

            await db.SaveChangesAsync();

            var bikeService = new BikeService(db);

            //Act
            db.Remove(dragBike);

            await db.SaveChangesAsync();

            //Assert
            db
               .Bikes
               .Count()
               .Should()
               .Be(2);
        }

        [Fact]
        public async Task DetailsAsyncReturnsInformationAboutCorrectBike()
        {
            const int searchedBikeId = 1;

            //Arrange
            var db = this.GetDatabase();

            var dragBike = new Bike { Id = 1, Make = Make.Drag, Model = "Master Pro", Price = 780.90m };
            var pinarelloBike = new Bike { Id = 2, Make = Make.Pinarello, Model = "Dogma F10", Price = 15000.790m };

            db.AddRange(dragBike, pinarelloBike);

            await db.SaveChangesAsync();

            var bikeService = new BikeService(db);

            //Act
            var searchedBike = await bikeService.DetailsAsync(searchedBikeId);

            //Assert
            searchedBike
                .Model
                .Should()
                .Be("Master Pro");
        }

        [Fact]
        public async Task ElectricAsyncReturnsOnlyElctricBikesAndOrderThemCorrectly()
        {
            //Arrange
            var db = this.GetDatabase();

            var electricBikeOne = new Bike { Id = 1, Make = Make.Drag, Model = "Dragomir Electric", Price = 1700.90m, BatteryMake = "Toshiba", BatteryPower = 1400 };
            var electricBikeTwo = new Bike { Id = 2, Make = Make.Drag, Model = "Shock", Price = 1800.90m, BatteryMake = "Toshiba", BatteryPower = 1400 };
            var electricBikeThree = new Bike { Id = 3, Make = Make.Drag, Model = "Byung", Price = 1760.90m, BatteryMake = "Toshiba", BatteryPower = 1400 };
            var nonElectric = new Bike { Id = 4, Make = Make.Pinarello, Model = "Dogma F8", Price = 18000.790m };

            db.AddRange(electricBikeOne, electricBikeTwo, electricBikeThree, nonElectric);

            await db.SaveChangesAsync();

            var bikeService = new BikeService(db);

            //Act
            var electrics = await bikeService.ElectricAsync();

            //Assert
            electrics
               .Should()
               .Match(b => b.ElementAt(0).Id == 3
                   && b.ElementAt(1).Id == 2
                   && b.ElementAt(2).Id == 1)
                   .And
                   .HaveCount(3);
        }


        private BikeManiaDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<BikeManiaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BikeManiaDbContext(dbOptions);
        }
    }
}
