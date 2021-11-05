using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
            var preAllClothes = _db.Clothes.Where(c => c.UserId == id).ToList();

            var weather = await _weatherService.GetWeather(id);
            var temperature = weather.Main.Feels_like;

            var allClothes = preAllClothes.Select(c => new
            {
                Diff = GetMetric(temperature, c.Temperature),
                Cloth = c
            })
            .OrderBy(x => x.Diff);

            ClothesDTO[] bestClothes = new ClothesDTO[6];

            bestClothes[0] = _mapper.Map<ClothesDTO>(allClothes.FirstOrDefault(c => c.Cloth.Type == ClothesType.HeadDress).Cloth);
            bestClothes[1] = _mapper.Map<ClothesDTO>(allClothes.FirstOrDefault(c => c.Cloth.Type == ClothesType.OuterWear).Cloth);
            bestClothes[2] = _mapper.Map<ClothesDTO>(allClothes.FirstOrDefault(c => c.Cloth.Type == ClothesType.MediumWear).Cloth);
            bestClothes[3] = _mapper.Map<ClothesDTO>(allClothes.FirstOrDefault(c => c.Cloth.Type == ClothesType.HandWear).Cloth);
            bestClothes[4] = _mapper.Map<ClothesDTO>(allClothes.FirstOrDefault(c => c.Cloth.Type == ClothesType.FootWear).Cloth);


            bestClothes[5] = new()
            {
                Name = weather.Weather[0].Main + " (" + weather.Weather[0].Description + ")",
                Temperature = (int)temperature
            };

            return bestClothes.ToList();
        }

        public static double GetMetric(double weather, double clothes)
        {
            var result = weather - clothes;
            if(result < 0)
                result *= -1.78; 
            return result;
        }
    }
}
