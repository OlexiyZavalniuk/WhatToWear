using System;
using System.Threading.Tasks;
using WhatToWear.Models.DTO;

namespace WhatToWear.Core
{
    public class HeatingCalculationService : IHeatingCalculationService
    {
        private readonly IGetWeatherService _weatherService;

        public HeatingCalculationService(IGetWeatherService getWeatherService)
        {
            _weatherService = getWeatherService;
        }

        public async Task<HeatingResultDTO> CalculateAsync(int id, double temperature, double square)
        {
            var weather = await _weatherService.GetWeather16DaysAsync(id);
            double loss = 0.0;

            foreach (var x in weather.Data)
            {
                loss += 86400.0 * GetHeatLoss(x.Min_temp, temperature, square) * ((temperature - x.Temp) / (temperature - x.Min_temp));
            }

            var result = new HeatingResultDTO()
            {
                KJ = loss,
                KW = loss / 3600,
                PriceGaz = loss / 4680,
                PriceElectric = loss * 1.68 / 3600
            };

            return result;
        }

        private static double GetHeatLoss(float out_temp, double temp, double square)
        {
                                                  // толщина стены   
                                                  // и коф. кирпича
            double walls_k = 1.0 / ((1.0 / 8.7) + (0.25 / 0.70) + (1.0 / 23.0)); //коеф потерь
            double walls = walls_k * Math.Sqrt(square) * 4.0 * 2.8; //потери для стен
            // потери для окон
            double windows = 2.3 * 2.8 * square / 10; //1 окно для 10 кв.м. площади
            // потери для крыши 
            double ceiling_k = 1.0 / ((1.0 / 8.7) + (0.22 / 0.24) + (1.0 / 12.0));
            double ceiling = ceiling_k * square;
            //потери для пола
            double floor_k = 1.0 / ((1.0 / 6) + (0.3 / 0.21) + (1.0 / 6.0));
            double floor = floor_k * square;

            return (walls + windows + ceiling + floor) * (temp - out_temp) / 1000.0;
        }
    }
}
