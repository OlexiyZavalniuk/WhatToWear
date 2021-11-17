using AutoMapper;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Clothes, OutClothesDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Clothes, ClothesDTO>();
        }
    }
}
