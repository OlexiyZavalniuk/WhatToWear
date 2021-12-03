using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWear.Models.DTO
{
    public class HeatingResultDTO
    {
        public double KJ { get; set; }

        public double KW { get; set; }

        public double PriceGaz { get; set; }

        public double PriceElectric { get; set; }
    }
}
