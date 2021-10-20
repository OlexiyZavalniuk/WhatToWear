using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Models.Models;

namespace WhatToWear.Models.DTO
{
    public class InClothesDTO : ClothesDTO
    {
        public int UserId { get; set; }
    }
}
