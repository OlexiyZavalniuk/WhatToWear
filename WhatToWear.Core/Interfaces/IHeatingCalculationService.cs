using System.Threading.Tasks;
using WhatToWear.Models.DTO;

namespace WhatToWear.Core
{
    public interface IHeatingCalculationService
    {
        Task<HeatingResultDTO> CalculateAsync(int id, double temperature, double square);
    }
}
