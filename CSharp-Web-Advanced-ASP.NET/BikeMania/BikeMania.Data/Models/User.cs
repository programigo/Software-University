namespace BikeMania.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<Bike> Bikes { get; set; } = new List<Bike>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
