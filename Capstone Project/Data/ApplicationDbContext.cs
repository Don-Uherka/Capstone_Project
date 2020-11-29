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
        public DbSet<Post> Posts { get; set; }
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
        }
        
    }
}
