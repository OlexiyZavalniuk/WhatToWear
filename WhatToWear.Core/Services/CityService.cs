using System;
using System.Collections.Generic;
using WhatToWear.Models.Models;
using WhatToWear.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatToWear.Core
{
    public class CityService
    {
        private readonly ApplicationContext _db;

        public CityService(ApplicationContext appContext)
        {
            _db = appContext;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(string toFind)
        {
            return await _db.Cities.Where(c => c.Name == toFind).ToListAsync();
        }
    }
}
