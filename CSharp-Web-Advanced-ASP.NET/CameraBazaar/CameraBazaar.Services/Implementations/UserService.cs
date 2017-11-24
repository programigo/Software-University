namespace CameraBazaar.Services.Implementations
{
    using CameraBazaar.Data;
    using CameraBazaar.Data.Models;
    using CameraBazaar.Services.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly CameraBazaarDbContext db;
        private readonly UserManager<User> userManager;

        public UserService(CameraBazaarDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public UserEditModel ById(string id)
        {
            return this.db
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserEditModel
                {
                    Email = u.Email,
                    NewPassword = u.PasswordHash,
                    Phonenumber = u.PhoneNumber,

                })
                .FirstOrDefault();
        }

        public UserDetailsModel Details(string id)
        {
            return this.db
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserDetailsModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email,
                    Phonenumber = u.PhoneNumber,
                    Cameras = u.Cameras,
                    IsCurrentlyLogged = true
        })
                .FirstOrDefault();
        }

        public void Edit(string id, string email, string password, string phonenumber)
        {
            var user = this.db.Users.Find(id);

            if (user == null)
            {
                return;
            }

            user.Email = email;
            user.PasswordHash = password;
            user.PhoneNumber = phonenumber;

            this.db.SaveChanges();
        }

        public UserDetailsModel FindById(string id)
        {
            return this.db
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserDetailsModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email,
                    Phonenumber = u.PhoneNumber,
                    Cameras = u.Cameras,
                    IsCurrentlyLogged = true
                })
                .FirstOrDefault();
        }
    }
}
