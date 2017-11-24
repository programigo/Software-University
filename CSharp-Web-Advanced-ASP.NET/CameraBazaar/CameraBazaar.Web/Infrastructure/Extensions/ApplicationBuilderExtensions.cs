namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using CameraBazaar.Data.Models;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminName = GlobalConstants.AdministratorRole;
                    var registeredUserName = GlobalConstants.RegisteredUser;

                    var adminRoleExists = await roleManager.RoleExistsAsync(adminName);
                    var registeredUserRoleExists = await roleManager.RoleExistsAsync(registeredUserName);

                    if (!adminRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }
                    else if (!registeredUserRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = registeredUserName
                        });
                    }

                    var adminEmail = "admin@mysite.com";

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, "undertaker");

                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
