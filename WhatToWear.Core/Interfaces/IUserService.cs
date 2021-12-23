using System.Collections.Generic;
using System.Threading.Tasks;
using WhatToWear.Models.DTO;

namespace WhatToWear.Core
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(string name);

        Task<UserDTO> GetUserAsync(int id);

        Task<List<UserDTO>> GetUsersAsync();

        Task DeleteUserAsync(int id);

        Task<UserDTO> UpdateUserAsync(UserDTO toUpdate);
    }
}
