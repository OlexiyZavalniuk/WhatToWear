using System.Collections.Generic;
using System.Threading.Tasks;
using WhatToWear.Models.DTO;

namespace WhatToWear.Core
{
    public interface IWhatToWearService
    {
        Task<List<ClothesDTO>> GetClothesOrderByWeatherForTrip(int id, double city);

        Task<List<WhatToWearDTO>> GetClothesOrderByWeather16DaysAsync(int id);

        Task<WhatToWearDTO> GetClothesOrderByWeatherAsync(int id);


    }
}
