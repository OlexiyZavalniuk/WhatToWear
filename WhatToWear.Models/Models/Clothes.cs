using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWear.Models.Models
{
    public class Clothes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Temperature { get; set; }

        public ClothesType Type { get; set; }

    }
}
