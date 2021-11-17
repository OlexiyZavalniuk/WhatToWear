using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WhatToWear.Models.Models;

namespace WhatToWear.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Clothes> Clothes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothes>()
                .HasOne(c => c.User)
                .WithMany(u => u.Clothes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
