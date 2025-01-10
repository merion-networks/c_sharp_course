using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using SystemProjectManager.Controllers;
using SystemProjectManager.DTOs.User;
using SystemProjectManeger.Services.Interfaces;
using Xunit;

namespace SystemProjectManager.Test
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> mockUserService;
        private readonly UsersController controller;

        public UsersControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            this.controller = new UsersController(mockUserService.Object);
        }

        [Fact]
        public async Task Register_ValidData_ReturnsOkResult()
        {
            // Arrange
            var registerDto = new RegisterDTO
            {
                Email = "test@test.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                FirstName = "testuser",
                LastName = "testuser"
            };
            mockUserService.Setup(x => x.RegisterAsync(registerDto))
                .ReturnsAsync(new UserDto { Id = 1, Email = registerDto.Email });

            // Act
            var result = await controller.Register(registerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(registerDto.Email, returnedUser.Email);
        }

        [Fact]
        public async Task Authenticate_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var loginDto = new LoginDTO
            {
                Email = "test@test.com",
                Password = "Password123!"
            };
            var expectedToken = "test-token";
            mockUserService.Setup(x => x.AuthenticateAsync(loginDto))
                .ReturnsAsync(expectedToken);

            // Act
            var result = await controller.Authenticate(loginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value;
            var tokenValue = returnValue.GetType().GetProperty("token")?.GetValue(returnValue);
            Assert.Equal(expectedToken, tokenValue);
        }

        [Fact]
        public async Task GetProfile_AuthenticatedUser_ReturnsUserProfile()
        {
            // Arrange
            var userId = 1;
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString())
        };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            var expectedUser = new UserDto { Id = userId, Email = "test@test.com" };
            mockUserService.Setup(x => x.GetProfileAsync(userId))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await controller.GetProfile();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal(expectedUser.Id, returnedUser.Id);
        }
    }
}
