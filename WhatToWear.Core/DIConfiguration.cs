﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using AutoMapper;
using System.Net.Http;

namespace WhatToWear.Core
{
    public static class DIConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));

            services.AddTransient<CityService>();
            services.AddTransient<UserService>();
            services.AddTransient<ClothesService>();
            services.AddTransient<WhatToWearService>();
            services.AddTransient<GetWeatherService>();
            services.AddSingleton<HttpClient>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            }).CreateMapper());
        }
    }
}
