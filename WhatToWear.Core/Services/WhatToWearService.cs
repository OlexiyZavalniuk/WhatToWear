using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class WhatToWearService
    {
        private readonly ApplicationContext _db;

        private readonly GetWeatherService _weatherService;

        private readonly IMapper _mapper;

        public WhatToWearService(ApplicationContext appContext, GetWeatherService getWeatherService, IMapper mapper)
        {
            _db = appContext;
            _weatherService = getWeatherService;
            _mapper = mapper;
        }

        public async Task<List<ClothesDTO>> GetClothesOrderByWeather(int id)
        {
            //маппинг в самом конце
            List<Clothes> preAllClothes = _db.Clothes.Where(c => c.UserId == id).ToList();
            List<ClothesDTO> allClothes = new();
            foreach(Clothes c in preAllClothes)
            {
                allClothes.Add(_mapper.Map<ClothesDTO>(c));
            }

            List<ClothesDTO>[] clothes = new List<ClothesDTO>[5];
            clothes[0] = allClothes.Where(c => c.Type == ClothesType.HeadDress).ToList();
            clothes[1] = allClothes.Where(c => c.Type == ClothesType.OuterWear).ToList();
            clothes[2] = allClothes.Where(c => c.Type == ClothesType.MediumWear).ToList();
            clothes[3] = allClothes.Where(c => c.Type == ClothesType.HandWear).ToList();
            clothes[4] = allClothes.Where(c => c.Type == ClothesType.FootWear).ToList();

            WeatherDTO weather = await _weatherService.GetWeather(id);
            double temperature = weather.Main.Feels_like;

            ClothesDTO[] bestClothes = new ClothesDTO[6];

            for(int i = 0; i < 5; i++)
            {
                bestClothes[i] = GetBest(clothes[i], temperature);
            }
            bestClothes[5] = new()
            {
                Name = weather.Weather[0].Main + " (" + weather.Weather[0].Description + ")",
                Temperature = (int)temperature
            };

            return bestClothes.ToList();
        }

        public static ClothesDTO GetBest(List<ClothesDTO> clothes, double temperature)
        {
            ClothesDTO best = new();
            double best_difference = 1000;

            foreach (ClothesDTO c in clothes)
            {
                double diff = GetMetric(temperature, c.Temperature);
                if(diff < best_difference)
                {
                    best_difference = diff;
                    best = c;
                }
            }

            return best;
        }

        public static double GetMetric(double weather, double clothes)
        {
            double result = weather - clothes;
            if(result < 0)
                result *= -1.78; 
            return result;
        }
    }
}
