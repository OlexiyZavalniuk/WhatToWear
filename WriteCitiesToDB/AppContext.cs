using System;
using Microsoft.EntityFrameworkCore;
using WhatToWear.Models.Models;

namespace WriteCitiesToDB
{
    public class AppContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClothesDTO> Clothes { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WhatToWear;Trusted_Connection=True;");
        }
    }
}
