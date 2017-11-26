using MessageBoardBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardBackend
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to zero
            //https://stackoverflow.com/questions/46441029/one-to-zero-relationship-with-entity-framework-core-2-0
            //https://docs.microsoft.com/en-us/ef/core/modeling/relationships#other-relationship-patterns
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<User>().HasOne(u => u.Company)
                .WithOne(p => p.User)
                .HasForeignKey<Company>(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many jobapps, jobpost

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany(u => u.JobApplications);

            modelBuilder.Entity<JobPost>()
                .HasOne(jp => jp.User)
                .WithMany(u => u.JobPosts);


            //one to many tags

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Tags);

            modelBuilder.Entity<JobPost>()
                .HasOne(jp => jp.Tags);


        }
    }
}
