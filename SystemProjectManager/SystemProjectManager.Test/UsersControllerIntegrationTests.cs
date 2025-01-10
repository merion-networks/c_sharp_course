using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SystemProjectManager.DTOs.User;
using Xunit;

namespace SystemProjectManager.Test
{
    public class UsersControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly HttpClient client;
        public UsersControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
            client = factory.CreateClient();
        }

        [Fact]
        public async Task RegisterValidUserReturnsSuccessResponse()
        {
            // Arrange
            var registerDto = new RegisterDTO
            {
                Email = "integration@test.com",
                Password = "Password123!",
                ConfirmPassword = "Password123!",
                FirstName = "integrationuser",
                LastName = "integrationuser",
                AvatarUrl = "https://example.com/avatar.jpg"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/users/register", registerDto);

            // Assert
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            Assert.NotNull(user);
            Assert.Equal(registerDto.Email, user.Email);
        }

        [Fact]
        public async Task AuthenticateValidCredentialsReturnsToken()
        {
            // Arrange
            var loginDto = new LoginDTO
            {
                Email = "integration@test.com",
                Password = "Password123!"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/users/authenticate", loginDto);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
            Assert.NotNull(result?.Token);
        }

        [Fact]
        public async Task GetProfileAuthenticatedUserReturnsProfile()
        {
            // Arrange
            // Сначала получаем токен
            var loginDto = new LoginDTO
            {
                Email = "integration@test.com",
                Password = "Password123!"
            };
            var authResponse = await client.PostAsJsonAsync("/api/users/authenticate", loginDto);
            var tokenResult = await authResponse.Content.ReadFromJsonAsync<TokenResponse>();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenResult.Token);

            // Act
            var response = await client.GetAsync("/api/users/profile");

            // Assert
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadFromJsonAsync<UserDto>();
            Assert.NotNull(user);
            Assert.Equal(loginDto.Email, user.Email);
        }

        private class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}
