using System;
using Microsoft.EntityFrameworkCore;
using WhatToWear.Models.Models;

namespace WhatToWear.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=whattowear;Trusted_Connection=True;");
        }
    }
}
