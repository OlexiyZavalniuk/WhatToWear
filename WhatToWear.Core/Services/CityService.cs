using System.Collections.Generic;
using WhatToWear.Models.Models;
using WhatToWear.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System;

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

        public async Task Initialising()
        {
            //Deserialize cities from file
            string json = File.ReadAllText("../WhatToWear.Database/Data/cities.json");
            var citiesList = JsonConvert.DeserializeObject<List<City>>(json);

            //Write cities to db

            foreach (City city in citiesList)
            {
                await _db.Cities.AddAsync(city);
            }
            await _db.SaveChangesAsync();
        }
    }
}
