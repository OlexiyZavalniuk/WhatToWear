using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WhatToWear.Database;
using AutoMapper;
using System.Net.Http;
using Hangfire;

namespace WhatToWear.Core
{
    public static class DIConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));

            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClothesService, ClothesService>();
            services.AddTransient<IWhatToWearService, WhatToWearService>();
            services.AddTransient<IGetWeatherService, GetWeatherService>();
            services.AddSingleton<HttpClient>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IHeatingCalculationService, HeatingCalculationService>();

            services.AddHangfire(opt =>
                    opt.UseSqlServerStorage(configuration.GetConnectionString("HangfireDB")));
            services.AddHangfireServer();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            }).CreateMapper());
        }
    }
}
