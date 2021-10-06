using System;
using System.Collections.Generic;
using WhatToWear.Models.Models;
using WhatToWear.Database;
using System.Linq;

namespace WhatToWear.Core
{
    public static class CityService
    {
        public static IEnumerable<City> GetCities(string toFind)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Cities.Where(c => c.Name == toFind).ToList();
            }
        }
    }
}
