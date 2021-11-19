﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;
using WhatToWear.Models.DTO2;

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

        public async Task<List<List<ClothesDTO>>> GetClothesOrderByWeather16DaysAsync(int id)
        {
            var weather = await _weatherService.GetWeather16DaysAsync(id);
            List<List<ClothesDTO>> clothes = new();

            foreach (Datum d in weather.Data)
            {
                var temperature = d.App_max_temp; 
                var description = d.Weather.Description + " (" + d.Valid_date + ")";

                clothes.Add(GetBestClothesWithWeather(id, temperature, description));
            }

            return clothes;
        }

        public async Task<List<ClothesDTO>> GetClothesOrderByWeatherAsync(int id)
        {
            var weather = await _weatherService.GetWeatherAsync(id);
            var temperature = weather.Main.Feels_like;
            var description = weather.Weather[0].Main + " (" + weather.Weather[0].Description + ")";

            return GetBestClothesWithWeather(id, temperature, description);
        }

        
        private List<ClothesDTO> GetBestClothesWithWeather(int id, double temperature, string description)
        {
            var bestClothes = GetBestClothes(id, temperature);

            bestClothes[5] = new()
            {
                Name = description,
                Temperature = (int)temperature
            };

            return bestClothes.ToList();
        }

        private ClothesDTO[] GetBestClothes(int id, double temperature)
        {
            var preAllClothes = _db.Clothes.Where(c => c.UserId == id).ToList();

            var allClothes = preAllClothes.Select(c => new
            {
                Diff = GetMetric(temperature, c.Temperature),
                Cloth = c
            })
            .OrderBy(x => x.Diff);

            ClothesDTO[] bestClothes = new ClothesDTO[6];

            bestClothes[0] = _mapper.Map<ClothesDTO>(allClothes.First(c => c.Cloth.Type == ClothesType.HeadDress).Cloth);
            bestClothes[1] = _mapper.Map<ClothesDTO>(allClothes.First(c => c.Cloth.Type == ClothesType.OuterWear).Cloth);
            bestClothes[2] = _mapper.Map<ClothesDTO>(allClothes.First(c => c.Cloth.Type == ClothesType.MediumWear).Cloth);
            bestClothes[3] = _mapper.Map<ClothesDTO>(allClothes.First(c => c.Cloth.Type == ClothesType.HandWear).Cloth);
            bestClothes[4] = _mapper.Map<ClothesDTO>(allClothes.First(c => c.Cloth.Type == ClothesType.FootWear).Cloth);

            return bestClothes;
        }

        private static double GetMetric(double weather, double clothes)
        {
            var result = weather - clothes;
            if (result < 0)
                result *= -1.78;
            return result;
        }
    }
}
