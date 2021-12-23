using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.DTO2;

namespace WhatToWear.Core
{
    public class GetWeatherService : IGetWeatherService
    {
        private readonly ApplicationContext _db;

        private readonly string _apiPath;

        private readonly string _apiPath16;

        private readonly HttpClient _client;

        public GetWeatherService(ApplicationContext appContext, HttpClient client, IConfiguration configuration)
        {
            _db = appContext;
            _apiPath = configuration.GetConnectionString("WeatherAPI");
            _apiPath16 = configuration.GetConnectionString("WeatherAPI16");
            _client = client;
        }

        public async Task<WeatherDTO> GetWeatherAsync(int id)
        {
            var user = _db.Users.First(u => u.Id == id);
            var path = _apiPath + user.City;

            return await _client.GetFromJsonAsync<WeatherDTO>(path);
        }

        public async Task<Weather16DTO> GetWeather16DaysAsync(int id)
        {
            var user = _db.Users.First(u => u.Id == id);
            var path = _apiPath16 + user.City;

            return await _client.GetFromJsonAsync<Weather16DTO>(path);
        }

        public async Task<Weather16DTO> GetWeather16DaysByCityIdAsync(double id)
        {
            var path = _apiPath16 + id;

            return await _client.GetFromJsonAsync<Weather16DTO>(path);
        }
    }
}
