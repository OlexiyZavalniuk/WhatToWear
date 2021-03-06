using System.ComponentModel.DataAnnotations;

namespace WhatToWear.Models.Models
{
    public class Clothes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Temperature { get; set; }

        public ClothesType Type { get; set; }

        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

    }
}
