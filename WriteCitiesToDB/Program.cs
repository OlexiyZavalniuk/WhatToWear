using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WhatToWear.Models.Models;

namespace WriteCitiesToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deserialize cities from file
            string json = File.ReadAllText("Data/cities.json");
            var citiesList = JsonConvert.DeserializeObject<List<City>>(json);

            //Write cities to db
            using (AppContext db = new())
            {
                foreach (City city in citiesList)
                {
                    db.Cities.Add(city);
                }
                db.SaveChanges();
                Console.WriteLine("OK!");
            }
        }
    }
}
