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

<<<<<<< HEAD
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Profile);
            modelBuilder.Entity<User>().HasOne(u => u.Company);

            /*modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
            */
        }
}
