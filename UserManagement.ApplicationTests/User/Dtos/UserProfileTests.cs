using AutoMapper;
using FluentAssertions;
using Xunit;

namespace UserManagement.Application.User.Dtos.Tests
{
    public class UserProfileTests
    {
        [Fact()]
        public void CreateMap_ForUserToUserDto_MapsCorrectly()
        {
            // arrange
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            var mapper = configuration.CreateMapper();

            var user = new UserDto()
            {
                Id = 2,
                Name = "Abram",
                Surname = "Mmako",
                Email = "Chesa@gmail.com",
                ContactNumber = "0799610258"              
            };

            // act 
            var userDto = mapper.Map<UserManagement.Domain.Entities.User> (user);

            // assert
            userDto.Should().NotBeNull();
            userDto.Name.Should().Be(user.Name);

        }
    }
}