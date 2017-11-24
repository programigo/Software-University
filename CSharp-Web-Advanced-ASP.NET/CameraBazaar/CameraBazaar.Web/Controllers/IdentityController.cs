namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Web.Infrastructure;
    using CameraBazaar.Web.Models.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class IdentityController : Controller
    {
        private readonly CameraBazaarDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityController(CameraBazaarDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var users = this.db
                .Users
                .OrderBy(u => u.Email)
                .Select(u => new ListUserViewModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email
                });

            return View(users);
        }

        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToList();

            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roleExists = await this.roleManager.RoleExistsAsync(role);

            if (user == null || !roleExists)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            TempData["SuccessMessage"] = $"User {user.Email} added to {role} role!";
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);

            return View(new UserWithRolesViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Roles = roles
            });
        }
    }
}
