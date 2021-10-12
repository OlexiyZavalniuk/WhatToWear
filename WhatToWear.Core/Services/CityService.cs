using System;
using System.Collections.Generic;
using WhatToWear.Models.Models;
using WhatToWear.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatToWear.Core
{
    public static class CityService
    {
        public static async Task<IEnumerable<City>> GetCitiesAsync(string toFind)
        {
            using ApplicationContext db = new();
            return await db.Cities.Where(c => c.Name == toFind).ToListAsync();
        }
    }
}
