using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.Models;

namespace WriteCitiesToDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Deserialize cities from file
            string json = File.ReadAllText("Data/cities.json");
            var citiesList = JsonConvert.DeserializeObject<List<City>>(json);

            //Write cities to db
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(City city in citiesList)
                {
                    db.Cities.Add(city);
                }
                db.SaveChanges();
                Console.WriteLine("OK!");
            }
        }
    }
}
