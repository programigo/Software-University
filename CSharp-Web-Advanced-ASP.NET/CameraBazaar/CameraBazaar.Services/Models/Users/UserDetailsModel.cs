namespace CameraBazaar.Services.Models.Users
{
    using CameraBazaar.Data.Models;
    using System.Collections.Generic;

    public class UserDetailsModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public List<Camera> Cameras { get; set; } = new List<Camera>();

        public bool IsCurrentlyLogged { get; set; }
    }
}
