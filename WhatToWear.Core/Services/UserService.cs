using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _db;

        private readonly IMapper _mapper; 

        public UserService(ApplicationContext appContext, IMapper mapper)
        {
            _db = appContext;
            _mapper = mapper;
        }

        public async Task<int> CreateUserAsync(string name)
        {
            
            User user = new();
            user.Name = name;

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            return _mapper.Map<UserDTO>(
                await _db.Users.Where(u => u.Id == id).FirstOrDefaultAsync());           
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _db.Users.ToListAsync();
            List<UserDTO> toReturn = new();
            foreach (User u in users)
            {
                toReturn.Add(_mapper.Map<UserDTO>(u));
            }
            return toReturn;
        }

        public async Task DeleteUserAsync(int id)
        {
            User user = new() { Id = id };
            _db.Users.Attach(user);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO toUpdate)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == toUpdate.Id);
            if (user == default(User))
            {
                throw new Exception();
            }
            user.Name = toUpdate.Name;
            user.Link = toUpdate.Link;
            user.City = toUpdate.City;
            await _db.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}
