using WhatToWear.Models.Models;

namespace WhatToWear.Models.DTO
{
    public class ClothesDTO
    {
        public string Name { get; set; }

        public int Temperature { get; set; }

        public ClothesType Type { get; set; }
    }
}
