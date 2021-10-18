using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Models.Models;

namespace WhatToWear.Models.DTO
{
    public class ClothesDTO
    {
        public string Name { get; set; }

        public int Temperature { get; set; }

        public ClothesType Type { get; set; }

        public int UserId { get; set; }
    }
}
