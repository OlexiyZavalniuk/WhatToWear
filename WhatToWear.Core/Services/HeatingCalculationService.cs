using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWear.Core
{
    public class HeatingCalculationService
    {
        private readonly GetWeatherService _weatherService;

        public HeatingCalculationService(GetWeatherService getWeatherService)
        {
            _weatherService = getWeatherService;
        }

        public async Task<double> CalculateAsync(int id, double temperature, double square)
        {
            var weather = await _weatherService.GetWeather16DaysAsync(id);
            double loss = 0.0;

            foreach (var x in weather.Data)
            {
                loss += 86400.0 * GetHeatLoss(x.Min_temp, temperature, square) * ((temperature - x.Temp) / (temperature - x.Min_temp));
            }

            return loss;
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
