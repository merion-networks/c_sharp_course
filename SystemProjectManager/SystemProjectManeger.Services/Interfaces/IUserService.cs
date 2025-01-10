using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.User;
using SystemProjectManager.Models.Entities;

namespace SystemProjectManeger.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDTO registerDto);
        Task<string> AuthenticateAsync(LoginDTO loginDto);
        Task<UserDto> GetProfileAsync(int userId);
        Task UpdateProfileAsync(int userId, UpdateUserDto updateUserDto);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto);
        Task ChangeUserRolesAsync(int adminUserId, ChangeUserRoleDto changeRoleDto);
        Task<string> UpdateAvatarAsync(int userId, IFormFile avatarFile);
    }
}
