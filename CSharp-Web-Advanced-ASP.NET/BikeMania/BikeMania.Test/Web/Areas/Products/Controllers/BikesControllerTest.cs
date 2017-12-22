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
            const Make DragMake = Make.Drag;
            const string BikeModel = "Master Pro";
            const decimal BikePrice = 890.67m;
            const string BikeImageUrl = "https://dragzone.bg/media/catalog/product/cache/1/image/500x500/9df78eab33525d08d6e5fb8d27136e95/_/3/_31466000117c_15074.jpg";
            const int BikeFrameSize = 550;
            const string BikeWheelesMake = "Kenda";
            const string BikeForkMake = "RockShock";
            const string BikeTiresMake = "Maxxis";
            const string BikeShiftersMake = "Dura Ace";
            const string BikeFrontDerailleur = "Verosice";
            const string BikeRearDerailleur = "Verosice";
            const string BikeChain = "Kenda"
            const string BikeSaddle = "Selle Italia";
            const string BikeHandlebar = "SomeTest";
            const string BikeBrakes = "Brembo";

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
                Make = DragMake,
                Model = BikeModel,
                Price = BikePrice,
                ImageUrl = BikeImageUrl,
                Quantity = 1,
                FrameSize = BikeFrameSize,
                WheelesMake = BikeWheelesMake,
                ForkMake = BikeForkMake,
                TiresMake = BikeTiresMake,
                ShiftersMake = BikeShiftersMake,
                FrontDerailleur = BikeFrontDerailleur,
                RearDerailleur = BikeRearDerailleur,
                Chain = BikeChain,
                Saddle = BikeSaddle,
                Handlebar = BikeHandlebar,
                Brakes = BikeBrakes
                
            });

            // Assert
            modelMake.Should().Be(Make.Drag);
            modelModel.Should().Be(BikeModel);
            modelPrice.Should().Be(BikePrice);
            modelImageUrl.Should().Be(BikeImageUrl);
            modelQuantity.Should().Be(1);
            modelFrameSize.Should().Be(BikeFrameSize);
            modelWheelesMake.Should().Be(BikeWheelesMake);
            modelForkMake.Should().Be(BikeForkMake);
            modelTiresMake.Should().Be(BikeTiresMake);
            modelShiftersMake.Should().Be(BikeShiftersMake);
            modelFrontDerailleur.Should().Be(BikeFrontDerailleur);
            modelRearDerailleur.Should().Be(BikeRearDerailleur);
            modelChain.Should().Be(BikeChain);
            modelSaddle.Should().Be(BikeSaddle);
            modelHandlebar.Should().Be(BikeHandlebar); ;
            modelBrakes.Should().Be(BikeBrakes);

            successMessage.Should().Be($"Bike {DragMake} {BikeModel} created successfully!");

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
