using SimpleMvc.App.BindingModels;
using SimpleMvc.App.Data;
using SimpleMvc.Domain.Entities;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel registerUserBinding)
        {
            if (!this.IsValidModel(registerUserBinding))
            {
                return this.View();
            }

            var user = new User
            {
                Username = registerUserBinding.Username,
                Password = registerUserBinding.Password
            };

            using (var context = new NotesDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (var context = new NotesDbContext())
            {
                var foundUser = context.Users.FirstOrDefault(u => u.Username == loginUserBinding.Username);

                if (foundUser == null)
                {
                    return RedirectToAction("/home/login");
                }

                context.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            Dictionary<int, string> users = new Dictionary<int, string>();

            using (var context = new NotesDbContext())
            {
                users = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] = users.Any()
                ? string.Join(string.Empty, users
                    .Select(u => $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
                : string.Empty;

            return this.View();
        }

        [HttpGet]
        public IActionResult Profile(int id)
        {
            using (var context = new NotesDbContext())
            {
                var user = context.Users
                    .FirstOrDefault(u => u.Id == id);

                this.Model["notes"] = string.Join(Environment.NewLine, user.Notes.Select(n => $"<li>{n.Title}</li>"));
            }

            //var viewModel = new UserProfileViewModel
            //{
            //    UserId = user.Id,
            //    Username = user.Username,
            //    Notes = user.Notes
            //    .Select(n =>
            //    new NoteViewModel
            //    {
            //        Title = n.Title,
            //        Content = n.Content
            //    })
            //};

            return this.View();
        }

        [HttpPost]
        public IActionResult Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesDbContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return this.Profile(model.UserId);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction("/home/index");
        }
    }
}