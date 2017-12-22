namespace BikeMania.Web.Areas.Products.Controllers
{
    using BikeMania.Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Bike;
    using System.Threading.Tasks;
    using Web.Areas.Products.Models.Bikes;

    [Area(GlobalConstants.ProductsArea)]
    public class BikesController : Controller
    {
        private readonly IBikeService bikes;
        private readonly UserManager<User> userManager;

        public BikesController(IBikeService bikes, UserManager<User> userManager)
        {
            this.bikes = bikes;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
           => View(new BikeListingViewModel
           {
               Bikes = await this.bikes.AllAsync(page),
               TotalBikes = await this.bikes.TotalAsync(),
               CurrentPage = page
           });

        [AllowAnonymous]
        public async Task<IActionResult> Road(int page = 1)
            => View(new BikeListingViewModel
            {
                Bikes = await this.bikes.RoadAsync(page),
                TotalBikes = await this.bikes.TotalRoadAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Mountain(int page = 1)
            => View(new BikeListingViewModel
            {
                Bikes = await this.bikes.MountainAsync(page),
                TotalBikes = await this.bikes.TotalMountainAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> SuspensionMountain(int page = 1)
            => View(new BikeListingViewModel
            {
                Bikes = await this.bikes.SuspensionMountainAsync(page),
                TotalBikes = await this.bikes.TotalSuspensionMountainAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Electric(int page = 1)
            => View(new BikeListingViewModel
            {
                Bikes = await this.bikes.ElectricAsync(page),
                TotalBikes = await this.bikes.TotalElectricAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Kids(int page = 1)
            => View(new BikeListingViewModel
            {
                Bikes = await this.bikes.KidsAsync(page),
                TotalBikes = await this.bikes.TotalKidsAsync(),
                CurrentPage = page
            });

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BikeFormModel bykeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bykeModel);
            }

            var userId = this.userManager.GetUserId(User);

            await this.bikes.CreateAsync(bykeModel.Make, bykeModel.Model, bykeModel.Price, bykeModel.ImageUrl, bykeModel.Quantity, bykeModel.FrameSize, bykeModel.WheelesMake, bykeModel.ForkMake, bykeModel.TiresMake, bykeModel.ShiftersMake, bykeModel.FrontDerailleur, bykeModel.RearDerailleur, bykeModel.Chain, bykeModel.Saddle, bykeModel.Handlebar, bykeModel.Brakes, bykeModel.Color, bykeModel.BrakeLevers, bykeModel.BatteryMake, bykeModel.BatteryPower, bykeModel.BarTape, bykeModel.RearShockMake, bykeModel.Kickstand, userId);

            TempData.AddSuccessMessage($"Bike {bykeModel.Make} {bykeModel.Model} created successfully!");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            return this.ViewOrNotFound(await this.bikes.DetailsAsync(id));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var bikeExists = await this.bikes.ExistsAsync(id, this.userManager.GetUserId(User));

            if (!bikeExists)
            {
                return NotFound();
            }

            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, BikeFormModel bikeModel)
        {
            var updatedBike = await this.bikes.EditAsync(
                id,
                bikeModel.Make,
                bikeModel.Model,
                bikeModel.Price,
                bikeModel.ImageUrl,
                bikeModel.Quantity,
                bikeModel.FrameSize,
                bikeModel.WheelesMake,
                bikeModel.ForkMake,
                bikeModel.TiresMake,
                bikeModel.ShiftersMake,
                bikeModel.FrontDerailleur,
                bikeModel.RearDerailleur,
                bikeModel.Chain,
                bikeModel.Saddle,
                bikeModel.Handlebar,
                bikeModel.Brakes,
                bikeModel.Color,
                bikeModel.BrakeLevers,
                bikeModel.BatteryMake,
                bikeModel.BatteryPower,
                bikeModel.BarTape,
                bikeModel.RearShockMake,
                bikeModel.Kickstand,
                this.userManager.GetUserId(User));

            if (!updatedBike)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Delete(int id)
            => View(id);

        [Authorize]
        public IActionResult Destroy(int id)
        {
            this.bikes.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
