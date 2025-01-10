using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.Project;
using SystemProjectManager.DTOs.User;
using SystemProjectManager.Models.Entities;
using SystemProjectManeger.Repositories.Interfaces;
using SystemProjectManeger.Services.Interfaces;

namespace SystemProjectManeger.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        private readonly IStorageService storageService;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IStorageService storageService)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this.storageService = storageService;
        }
        public async Task<string> AuthenticateAsync(LoginDTO loginDto)
        {
            var user = await userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Недействительные учетные данные");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (!BCrypt.Net.BCrypt.Verify(changePasswordDto.CurrentPassword, user.PasswordHash))
            {
                throw new Exception("Текущий пароль неверный");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
            await userRepository.UpdateAsync(user);
        }

        public async Task ChangeUserRolesAsync(int adminUserId, ChangeUserRoleDto changeRoleDto)
        {
            var user = await userRepository.GetByIdAsync(changeRoleDto.UserId);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            // Очистить существующие роли
            user.UserRoles.Clear();

            foreach (var roleName in changeRoleDto.NewRoles)
            {
                var role = await userRepository.GetAllRoleAsync(roleName);
                if (role == null)
                {
                    throw new Exception($"Роль {roleName} не найдена");
                }
                user.UserRoles.Add(new UserRole { Role = role });
            }

            await userRepository.UpdateAsync(user);
        }

        public async Task<UserDto> GetProfileAsync(int userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await userRepository.GetAllAsync();

            if (users == null)
            {
                throw new Exception("Пользователи не найден");
            }

            var userssDTO = new List<UserDto>();

            foreach (var user in users)
            {
                userssDTO.Add(new UserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AvatarUrl = user.AvatarUrl,
                    Roles = user.UserRoles?.Select(ur => ur.RoleId.ToString()).ToList()
                });
            }

            return userssDTO;
        }

        public async Task<UserDto> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email уже используется другим пользователем!");
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                AvatarUrl = registerDto.AvatarUrl
            };

            // Добавление роли по умолчанию
            var defaultRole =  await userRepository.GetAllRoleAsync("User");

            user.UserRoles = new List<UserRole> {
                new UserRole { Role = defaultRole }
            };

            await userRepository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };

        }

        public async Task<string> UpdateAvatarAsync(int userId, IFormFile avatarFile)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (avatarFile == null || avatarFile.Length == 0)
            {
                throw new Exception("Файл не выбран");
            }

            // Если у пользователя уже есть аватар, удаляем старый файл
            if (!string.IsNullOrEmpty(user.AvatarUrl))
            {
                await storageService.DeleteFileAsync(user.AvatarUrl);
            }

            // Загружаем новый файл
            string avatarUrl = await storageService.UploadFileAsync(avatarFile);

            // Обновляем URL аватара пользователя
            user.AvatarUrl = avatarUrl;
            await userRepository.UpdateAsync(user);

            return avatarUrl;
        }

        public async Task UpdateProfileAsync(int userId, UpdateUserDto updateUserDto)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            // Обновление данных пользователя
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.AvatarUrl = updateUserDto.AvatarUrl;

            await userRepository.UpdateAsync(user);
        }


    }
}
