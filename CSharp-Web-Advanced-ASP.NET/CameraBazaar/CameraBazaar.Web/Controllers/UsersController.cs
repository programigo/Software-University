namespace CameraBazaar.Web.Controllers
{
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services;
    using CameraBazaar.Web.Models.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserService users;
        private UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        [Route("{id}")]
        public IActionResult Details(string id)
        {
            var user = this.users.FindById(id);

            var isLoggedUser = id == this.userManager.GetUserId(User);

            if (!isLoggedUser)
            {
                user.IsCurrentlyLogged = false;
            }

            return View(user);
        }

        [Authorize]
        [Route("edit/{id}")]
        public IActionResult Edit(string id)
        {
            var user = this.users.ById(id);

            if (user == null)
            {
                return NotFound();
            }


            return View(new UserFormModel
            {
                Email = user.Email,
                NewPassword = user.NewPassword,
                Phonenumber = user.Phonenumber,
                IsCurrentlyLogged = id == this.userManager.GetUserId(User)
            });
        }

        [Authorize]
        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(string id, UserFormModel userModel)
        {
            var allowedToEdit = id == this.userManager.GetUserId(User);

            if (!allowedToEdit)
            {
                //userModel.IsCurrentlyLogged = false;
                return Unauthorized();
            }         

            this.users.Edit(
                id,
                userModel.Email,
                userModel.NewPassword,
                userModel.Phonenumber);

            return RedirectToAction(nameof(Details));
        }
    }
}
