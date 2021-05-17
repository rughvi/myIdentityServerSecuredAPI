using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace identityServer.db
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any board games.
                if (context.Users.Any())
                {
                    return;   // Data was already seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Id = "1",
                        Email = "User1@abc.com",
                        Password = "UserPwd1",
                        Active = true
                    });

                context.SaveChanges();
            }
        }
    }
}
