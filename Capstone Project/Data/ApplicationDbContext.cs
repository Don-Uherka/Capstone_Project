using System;
using System.Collections.Generic;
using System.Text;
using Capstone_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Events> Event { get; set; }
        public DbSet<SharePost> SharePosts { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Participant",
                NormalizedName = "PARTICIPANT"
            }
            );
            base.OnModelCreating(builder);
            builder.Entity<Events>()
            .HasData(
            new Events
            {

                Id = 1,
                Name = "walk",
                Description = "walk",
                StartDate = new DateTime(2020, 10, 11),
                EndDate = new DateTime(2020, 10, 11),
                Address1 = "117 walnut street",
                City = "Beaver Dam",
                State = "WI",
                ZipCode = 53916,
                Country = "USA",
                Latitude = 10,
                Longitude = 10,
                Founder = "Don"
            }
            );
        }

    }
}
