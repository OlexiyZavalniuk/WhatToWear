using Microsoft.Extensions.Configuration;
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

        public GetWeatherService(ApplicationContext appContext, HttpClient client, IConfiguration configuration)
        {
            _db = appContext;
            _apiPath = configuration.GetConnectionString("WeatherAPI");
            _client = client;
        }

        public async Task<WeatherDTO> GetWeather(int id)
        {
            User user = _db.Users.First(u => u.Id == id);
            string path = _apiPath + "&id=" + user.City + "&units=Metric";

            return await _client.GetFromJsonAsync<WeatherDTO>(path);
        }
    }
}
