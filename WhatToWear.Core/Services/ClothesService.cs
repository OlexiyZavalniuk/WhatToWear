using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class ClothesService
    {
        private readonly ApplicationContext _db;

        public ClothesService(ApplicationContext appContext)
        {
            _db = appContext;
        }

        public async Task AddClothesAsync(ClothesDTO clothes)
        {
            User user = await _db.Users.Include(u => u.Clothes)
                .FirstOrDefaultAsync(u => u.Id == clothes.UserId);
            Clothes c = new()
            {
                Name = clothes.Name,
                Temperature = clothes.Temperature,
                Type = clothes.Type,
            };
            user.Clothes.Add(c);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveClothesAsync(int id)
        {
            Clothes clothes = new() { Id = id };
            _db.Clothes.Attach(clothes);
            _db.Clothes.Remove(clothes);
            await _db.SaveChangesAsync();
        }
    }
}
