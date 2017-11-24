namespace CameraBazaar.Services
{
    using CameraBazaar.Services.Models.Users;

    public interface IUserService
    {
        UserDetailsModel Details(string id);

        UserEditModel ById(string id);

        UserDetailsModel FindById(string id);

        void Edit(string id, string email, string password, string phonenumber);
    }
}
