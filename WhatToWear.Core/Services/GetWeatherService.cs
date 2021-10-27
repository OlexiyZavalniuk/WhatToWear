using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class GetWeatherService
    {
        private readonly ApplicationContext _db;

        private readonly string _apiPath;

        private readonly HttpClient _client;

        public GetWeatherService(ApplicationContext appContext)
        {
            _db = appContext;
            _apiPath = "https://api.openweathermap.org/data/2.5/weather?appid=d1df6d38b7583aba9cf9018fb7cbf442";
            _client = new HttpClient();
        }

        public WeatherDTO GetWeather(int id)
        {
            User user = _db.Users.First(u => u.Id == id);
            string path = _apiPath + "&id=" + user.City + "&units=Metric";

            return _client.GetFromJsonAsync<WeatherDTO>(path).Result;
        }
    }
}
