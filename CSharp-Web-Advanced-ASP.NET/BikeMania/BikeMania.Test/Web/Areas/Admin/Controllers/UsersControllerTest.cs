namespace BikeMania.Test.Web.Areas.Admin.Controllers
{
    using BikeMania.Web;
    using BikeMania.Web.Areas.Admin.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class UsersControllerTest
    {
        [Fact]
        public void UsersControllerIsInAdminArea()
        {
            // Arrange
            var controller = typeof(UsersController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;     

            // Assert
            areaAttribute.Should().NotBeNull();      
            areaAttribute.RouteValue.Should().Be(GlobalConstants.AdminArea);  
        }

        [Fact]
        public void UsersControllerIsAuthorizedOnlForAdmins()
        {
            // Arrange
            var controller = typeof(UsersController);

            // Act
            var authorizeAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            authorizeAttribute.Should().NotBeNull();
            authorizeAttribute.Roles.Should().Be(GlobalConstants.AdministratorRole);
        }

        //[Fact]
        //public async Task AddToRole
    }
}
