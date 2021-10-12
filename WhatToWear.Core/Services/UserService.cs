using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.Models;

namespace WhatToWear.Core.Services
{
    public static class UserService
    {
        public static async Task<int> CreateUser(string name)
        {
            using ApplicationContext db = new();
            
            User user = new();
            int id = await db.Users.MaxAsync(u => u.Id);
            user.Id = ++id;
            user.Name = name;

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return user.Id;
        }

        public static async void SetLink(int id, string link)
        {
            using ApplicationContext db = new();

            User user = await db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            user.Link = link;
            await db.SaveChangesAsync();
        }
    }
}
