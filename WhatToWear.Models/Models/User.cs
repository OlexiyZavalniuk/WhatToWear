using System.Collections.Generic;

namespace WhatToWear.Models.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double City { get; set; }

        public string Link { get; set; }

        public List<Clothes> Clothes { get; set; }
    }
}
