using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class UserService
    {
        private ApplicationContext _db;

        public UserService(ApplicationContext appContext)
        {
            _db = appContext;
        }
        public async Task<int> CreateUserAsync(string name)
        {
            
            User user = new();
            user.Name = name;

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user.Id;
        }

        public async Task DeleteUserAsync(int id)
        {
            User customer = new() { Id = id };
            _db.Users.Attach(customer);
            _db.Users.Remove(customer);
            await _db.SaveChangesAsync();
        }

        public async void SetLinkAsync(int id, string link)
        {
            User user = await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            user.Link = link;
            await _db.SaveChangesAsync();
        }

    }
}
