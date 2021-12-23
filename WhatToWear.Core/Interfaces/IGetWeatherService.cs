using System.Threading.Tasks;
using WhatToWear.Models.DTO;
using WhatToWear.Models.DTO2;

namespace WhatToWear.Core
{
    public interface IGetWeatherService
    {
        Task<WeatherDTO> GetWeatherAsync(int id);

        Task<Weather16DTO> GetWeather16DaysAsync(int id);

        Task<Weather16DTO> GetWeather16DaysByCityIdAsync(double id);
    }
}
