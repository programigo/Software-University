namespace BikeMania.Test.Web.Areas.Products.Controllers
{
    using BikeMania.Data.Models;
    using BikeMania.Services.Bike;
    using BikeMania.Test.Mocks;
    using BikeMania.Web;
    using BikeMania.Web.Areas.Products.Controllers;
    using BikeMania.Web.Areas.Products.Models.Bikes;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Moq;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class BikesControllerTest
    {
        [Fact]
        public void DeleteShouldBeAvalableOnlyForAuthorizedMembers()
        {
            //Arrange
            var method = typeof(BikesController).GetMethod(nameof(BikesController.Delete));

            //Act
            var attributes = method.GetCustomAttributes(true);

            //Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public async Task PostCreateShouldReturnRedirectWitValidModel()
        {
            // Arrange
            Make modelMake = Make.Drag;
            string modelModel = null;
            decimal modelPrice = default(decimal);
            string modelImageUrl = null;
            int modelQuantity = default(int);
            int modelFrameSize = default(int);
            string modelWheelesMake = null;
            string modelForkMake = null;
            string modelTiresMake = null;
            string modelShiftersMake = null;
            string modelFrontDerailleur = null;
            string modelRearDerailleur = null;
            string modelChain = null;
            string modelSaddle = null;
            string modelHandlebar = null;
            string modelBrakes = null;
            string modelColor = null;
            string modelBrakeLevers = null;
            string modelBatteryMake = null;
            int? modelBatteryPower = null;
            string modelBarTape = null;
            string modelRearShockMake = null;
            string modelKickstand = null;
            string modelUserId = null;

            string successMessage = null;

            var userManager = UserManagerMock.New;
            var bikeService = new Mock<IBikeService>();

            bikeService
                .Setup(b => b.CreateAsync(
                    It.IsAny<Make>(),
                    It.IsAny<string>(),
                    It.IsAny<decimal>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                    .Callback((Make make,
            string model,
            decimal price,
            string imageUrl,
            int quantity,
            int frameSize,
            string wheelesMake,
            string forkMake,
            string tiresMake,
            string shiftersMake,
            string frontDerailleur,
            string rearDerailleur,
            string chain,
            string saddle,
            string handlebar,
            string brakes
            ) =>
                    {
                        modelMake = make;
                        modelModel = model;
                        modelPrice = price;
                        modelImageUrl = imageUrl;
                        modelQuantity = quantity;
                        modelFrameSize = frameSize;
                        modelWheelesMake = wheelesMake;
                        modelForkMake = forkMake;
                        modelTiresMake = tiresMake;
                        modelShiftersMake = shiftersMake;
                        modelFrontDerailleur = frontDerailleur;
                        modelRearDerailleur = rearDerailleur;
                        modelChain = chain;
                        modelSaddle = saddle;
                        modelHandlebar = handlebar;
                        modelBrakes = brakes;
                        
                    })
                    .Returns(Task.CompletedTask);

            var tempData = new Mock<ITempDataDictionary>();
            tempData.SetupSet(t => t[GlobalConstants.TempDataSuccessMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => successMessage = message as string);

            var controller = new BikesController(bikeService.Object, userManager.Object);
            controller.TempData = tempData.Object;

            // Act
            var result = await controller.Create(new BikeFormModel
            {
                Make = Make.Drag,
                Model = "Master Pro",
                Price = 890.67m,
                ImageUrl = "https://dragzone.bg/media/catalog/product/cache/1/image/500x500/9df78eab33525d08d6e5fb8d27136e95/_/3/_31466000117c_15074.jpg",
                Quantity = 1,
                FrameSize = 550,
                WheelesMake = "Kenda",
                ForkMake = "RockShock",
                TiresMake = "Maxxis",
                ShiftersMake = "Dura Ace",
                FrontDerailleur = "Verosice",
                RearDerailleur = "Verosice",
                Chain = "Kenda",
                Saddle = "Selle Italia",
                Handlebar = "SomeTest",
                Brakes = "Brembo"
                
            });

            // Assert
            modelMake.Should().Be(Make.Drag);
            modelModel.Should().Be("Master Pro");
            modelPrice.Should().Be(890.67m);
            modelImageUrl.Should().Be("https://dragzone.bg/media/catalog/product/cache/1/image/500x500/9df78eab33525d08d6e5fb8d27136e95/_/3/_31466000117c_15074.jpg");
            modelQuantity.Should().Be(1);
            modelFrameSize.Should().Be(550);
            modelWheelesMake.Should().Be("Kenda");
            modelForkMake.Should().Be("RockShock");
            modelTiresMake.Should().Be("Maxxis");
            modelShiftersMake.Should().Be("Dura Ace");
            modelFrontDerailleur.Should().Be("Verosice");
            modelRearDerailleur.Should().Be("Verosice");
            modelChain.Should().Be("Kenda");
            modelSaddle.Should().Be("Selle Italia");
            modelHandlebar.Should().Be("SomeTest"); ;
            modelBrakes.Should().Be("Brembo");

            successMessage.Should().Be($"Bike {Make.Drag} {"Master Pro"} created successfully!");

            result.Should().BeOfType<RedirectToActionResult>();

            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
        }

        [Fact]
        public async Task EditShouldReturnNotFoundIfBikeDoesNotExist()
        {
            //Arrange
            var userManager = UserManagerMock.New;

            var controller = new BikesController(null, userManager.Object);

            //userManager.Setup()

            //Act
            var result = await controller.Edit(1);

            //Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }
    }
}
