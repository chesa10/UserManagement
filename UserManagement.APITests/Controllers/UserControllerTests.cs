using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using FluentAssertions;
using Moq;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.DataSeeders;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Entities;
using System.Net.Http.Json;
using UserManagement.Application.User.Dtos;

namespace UserManagement.API.Controllers.Tests
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IGroupSeeder> _seedData = new();

        public UserControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.Replace(ServiceDescriptor.Scoped(typeof(IUserRepository), _ => _userRepositoryMock.Object));
                });
            });
        }

        [Fact()]
        public async void GetUserList_ForValidRequest_Return200Ok()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync("/api/user/GetUserList");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async void GetUserList_ForInvalidRequest_Return404NotFound()
        {
            // arrange
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync("/api/user");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }


        // Delete user tests
        [Fact()]
        public async void DeleteUser_ForValidUserId_Return204NoContent()
        {
            // arrange
            var id = 2; 
            
            var user = new User()
            {
                Id = id,
                Name = "Abram",
                Surname = "Mmako",
            };
            _userRepositoryMock.Setup(u => u.GetByIdAsync(id)).ReturnsAsync(user);
            var client = _factory.CreateClient();

            // act
            var result = await client.DeleteAsync($"/api/user/DeleteUser/{id}");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact()]
        public async void DeleteUser_ForInvalidUserId_Return404NotFound()
        {
            // arrange
            var id = -1;
            _userRepositoryMock.Setup(u => u.GetByIdAsync(id)).ReturnsAsync((User?)null);
            var client = _factory.CreateClient();

            // act
            var result = await client.DeleteAsync($"/api/user/DeleteUser/{id}");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        // GetUserById action test
        [Fact()]
        public async void GetUserById_ForValidUserId_Return200Ok()
        {
            // arrange
            var id = 2;
            var user = new User() 
            { 
                Id = id,
                Name = "Abram",
                Surname = "Mmako",
            };

            _userRepositoryMock.Setup(u => u.GetByIdAsync(id)).ReturnsAsync(user);
            var client = _factory.CreateClient();

            // act
            var result = await client.GetAsync($"/api/user/GetUserById/{id}");
            var userDto = await result.Content.ReadFromJsonAsync<UserDto>();

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            userDto.Should().NotBeNull();
            userDto.Name.Should().Be("Abram");
            userDto.Surname.Should().Be("Mmako");
        }
    }
}