
namespace WhatToWear.Models.DTO2
{

    public class Weather16DTO
    {
        public Datum[] Data { get; set; }
        public string City_name { get; set; }
        public string Lon { get; set; }
        public string Timezone { get; set; }
        public string Lat { get; set; }
        public string Country_code { get; set; }
        public string State_code { get; set; }
    }

    public class Datum
    {
        public int Moonrise_ts { get; set; }
        public string Wind_cdir { get; set; }
        public int Rh { get; set; }
        public float Pres { get; set; }
        public float High_temp { get; set; }
        public int Sunset_ts { get; set; }
        public float Ozone { get; set; }
        public float Moon_phase { get; set; }
        public float Wind_gust_spd { get; set; }
        public float Snow_depth { get; set; }
        public int Clouds { get; set; }
        public int Ts { get; set; }
        public int Sunrise_ts { get; set; }
        public float App_min_temp { get; set; }
        public float Wind_spd { get; set; }
        public int Pop { get; set; }
        public string Wind_cdir_full { get; set; }
        public float Slp { get; set; }
        public float Moon_phase_lunation { get; set; }
        public string Valid_date { get; set; }
        public float App_max_temp { get; set; }
        public float Vis { get; set; }
        public float Dewpt { get; set; }
        public float Snow { get; set; }
        public float Uv { get; set; }
        public Weather Weather { get; set; }
        public int Wind_dir { get; set; }
        public object Max_dhi { get; set; }
        public int Clouds_hi { get; set; }
        public float Precip { get; set; }
        public float Low_temp { get; set; }
        public float Max_temp { get; set; }
        public int Moonset_ts { get; set; }
        public string Datetime { get; set; }
        public float Temp { get; set; }
        public float Min_temp { get; set; }
        public int Clouds_mid { get; set; }
        public int Clouds_low { get; set; }
    }

    public class Weather
    {
        public string Icon { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }

}
