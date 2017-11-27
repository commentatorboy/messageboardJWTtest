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

                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }



                context.Companies.Add(new Company
                {
                    CVR = "",
                    Id = "",
                    Name = "",
                    TypeOfCompany = ""
                });

                context.Tags.Add(new Tag
                {
                    Descriptipon = "",
                    Title = "",
                    Id = "",
                });

                //for the profile
                context.Users.Add(new User
                {
                    Email = "company",
                    FirstName = "tim",
                    LastName = "timm",
                    Password = "a",
                    Id = "1",
                    MyRole = Role.Profile
                });

                //for the company
                context.Users.Add(new User
                {
                    Email = "profile",
                    FirstName = "hen",
                    Password = "a",
                    Id = "2",
                    MyRole = Role.Company
                });

                //for the profile
                context.JobApplications.Add(new JobApplication
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = "",
                    Description = "",
                    Id = "",
                    Tags = context.Tags.FirstOrDefault(),
                    Title = "",
                    UpdatedAt = DateTime.Now,
                    User = context.Users.FirstOrDefault()
                });


                context.JobPosts.Add(new JobPost
                {
                    CreatedAt = "",
                    CreatedBy = "",
                    Description = "",
                    Id = "",
                    Tags = context.Tags.FirstOrDefault(),
                    Title = "",
                    UpdatedAt = "",
                    User = context.Users.FirstOrDefault()
                    
                });

                context.SaveChanges();

            }
        }
    }
}