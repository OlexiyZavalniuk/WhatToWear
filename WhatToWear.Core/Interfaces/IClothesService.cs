using System.Collections.Generic;
using System.Threading.Tasks;
using WhatToWear.Models.DTO;

namespace WhatToWear.Core
{
    public interface IClothesService
    {
        Task AddClothesAsync(InClothesDTO clothes);

        Task RemoveClothesAsync(int id);

        Task<List<OutClothesDTO>> GetClothesAsync(int id);
    }
}
