
namespace WhatToWear.Models.DTO
{
    public class NameDayDTO
    {
        public string Status { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public Namedays Namedays { get; set; }
    }

    public class Namedays
    {
        public string At { get; set; }
        public string Bg { get; set; }
        public string Cz { get; set; }
        public string De { get; set; }
        public string Dk { get; set; }
        public string Ee { get; set; }
        public string Es { get; set; }
        public string Fi { get; set; }
        public string Fr { get; set; }
        public string Gr { get; set; }
        public string Hr { get; set; }
        public string Hu { get; set; }
        public string It { get; set; }
        public string Lt { get; set; }
        public string Lv { get; set; }
        public string Pl { get; set; }
        public string Ru { get; set; }
        public string Se { get; set; }
        public string Sk { get; set; }
        public string Us { get; set; }
    }

}
