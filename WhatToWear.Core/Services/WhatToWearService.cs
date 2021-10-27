using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;

namespace WhatToWear.Core
{
    public class WhatToWearService
    {
        private readonly ApplicationContext _db;

        private GetWeatherService _weatherService;

        public WhatToWearService(ApplicationContext appContext)
        {
            _db = appContext;
            _weatherService = new(appContext);
        }


    }
}
