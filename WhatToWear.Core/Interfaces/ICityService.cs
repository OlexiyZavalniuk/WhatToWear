using System.Collections.Generic;
using System.Threading.Tasks;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync(string toFind);

        Task Initialising();
    }
}
