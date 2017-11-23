using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MessageBoardBackend;
using MessageBoardBackend.Models;

namespace MessageBoardBackend.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                // Look for any movies.
                if (context.Messages.Any())
                {
                    return;   // DB has been seeded
                }
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }


                context.Messages.Add(
                    new Message { Owner = "John", Text = "hello" }
                );

                context.Messages.Add(
                    new Message { Owner = "tim", Text = "hi" }
                );

                context.Users.Add(new User
                {
                    Email = "a",
                    FirstName = "tikm",
                    Password = "a",
                    Id = "1"
                });
                context.SaveChanges();

            }
        }
    }
}