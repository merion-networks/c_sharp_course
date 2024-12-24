using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.User;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDTO registerDto);
        Task<string> AuthenticateAsync(LoginDTO loginDto);
        Task<UserDto> GetProfileAsync(int userId);
        Task UpdateProfileAsync(int userId, UpdateUserDto updateUserDto);
    }
}
