namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Services;
    using LearningSystem.Web.Models;
    using LearningSystem.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICourseService courses;
        private readonly IUserService users;

        public HomeController(ICourseService courses, IUserService users)
        {
            this.courses = courses;
            this.users = users;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeIndexViewModel
            {
                Courses = await this.courses.ActiveAsync()
            });
        }
            
        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                Searchtext = model.SearchText
            };

            if (model.SearchInCourses)
            {
                viewModel.Courses = await this.courses.FindAsync(model.SearchText);
            }

            if (model.SearchInUsers)
            {
                viewModel.Users = await this.users.FindAsync(model.SearchText);
            }

            return View(viewModel);
        }
     
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
