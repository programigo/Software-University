namespace BikeMania.Web.Controllers
{
    using BikeMania.Data.Models;
    using BikeMania.Services.Bike;
    using BikeMania.Web.Areas.Products.Models.Bikes;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IBikeService bikes;
        private readonly UserManager<User> userManager;

        public HomeController(IBikeService bikes, UserManager<User> userManager)
        {
            this.bikes = bikes;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        => View(new BikeListingViewModel
        {
            Bikes = await this.bikes.AllAsync(page),
            TotalBikes = await this.bikes.TotalAsync(),
            CurrentPage = page
        });

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
