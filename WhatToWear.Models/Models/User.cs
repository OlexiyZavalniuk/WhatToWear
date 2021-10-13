﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWear.Models.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public DateTime Time { get; set; }

        public List<Clothes> Clothes { get; set; }

        public string Link { get; set; }
    }
}
