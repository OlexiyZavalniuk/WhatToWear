﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class ClothesService
    {
        private readonly ApplicationContext _db;

        private readonly Mapper _mapper;

        public ClothesService(ApplicationContext appContext)
        {
            _db = appContext;
            var mapConf = new MapperConfiguration(cfg => cfg.CreateMap<Clothes, OutClothesDTO>());
            _mapper = new Mapper(mapConf);
        }

        public async Task AddClothesAsync(InClothesDTO clothes)
        {
            User user = await _db.Users.Include(u => u.Clothes)
                .FirstOrDefaultAsync(u => u.Id == clothes.UserId);
            Clothes c = new()
            {
                Name = clothes.Name,
                Temperature = clothes.Temperature,
                Type = clothes.Type,
            };
            user.Clothes.Add(c);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveClothesAsync(int id)
        {
            Clothes clothes = new() { Id = id };
            _db.Clothes.Attach(clothes);
            _db.Clothes.Remove(clothes);
            await _db.SaveChangesAsync();
        }

        public async Task<List<OutClothesDTO>> GetClothesAsync(int id)
        {
            List<Clothes> clothes =  await _db.Clothes.Where(c => c.UserId == id).ToListAsync();
            List<OutClothesDTO> toReturn = new();
            foreach (Clothes c in clothes)
            {
                toReturn.Add(_mapper.Map<OutClothesDTO>(c));
            }
            return toReturn;
        }
    }
}