using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using UserManagement.Domain.Repositories;
using Xunit;

namespace UserManagement.Application.User.Commands.AddUser.Tests
{
    public class AddUserHandlerTests
    {
        [Fact()]
        public async Task Handle_ForValidAddUserRequest_ReturnsCreatedUserId()
        {
            // arrange
            var loggerMock = new Mock<ILogger<AddUserHandler>>();

            var mapperMock = new Mock<IMapper>();
            var command = new AddUserRequest();
            command.GroupIds = [1, 2];
            var user = new Domain.Entities.User();
            mapperMock.Setup(m => m.Map<Domain.Entities.User>(command)).Returns(user);

            IEnumerable<Domain.Entities.Group> groups = [
            new()
            {
                Id = 1,
                Name = "Third part cover Group",
                Description = "The most basic level of coverage, focusing on protecting you from legal liability if you cause damage to another person's vehicle"
            },
            new()
            {
                Id = 2,
                Name = "Comprehensive cover Group",
                Description = "The most extensive protection, covering various risks like accidents, theft, vandalism, fire, and natural disasters, as well as third-party liability"
            }
            ];

            var groupRepositoryMock = new Mock<IGroupRepository>();
            groupRepositoryMock.Setup(repo => repo.GetAllAsync())
                              .ReturnsAsync(groups);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Create(It.IsAny<UserManagement.Domain.Entities.User>()))
                              .ReturnsAsync(1);

            var commandHandler = new AddUserHandler(userRepositoryMock.Object, groupRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

            // act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // assert
            result.Should().Be(1);
        }
    }
}