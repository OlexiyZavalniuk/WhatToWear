using System.Collections.Generic;

namespace WhatToWear.Models.DTO
{
    public class WhatToWearDTO
    {
        public List<ClothesDTO> Clothes { get; set; }

        public WeatherWTW Weather { get; set; }
    }

    public class WeatherWTW
    { 
        public string Description { get; set; }

        public int Temperature { get; set; }
    }
}
