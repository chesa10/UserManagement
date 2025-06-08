using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using UserManagement.Domain.Exceptions;
using UserManagement.Domain.Repositories;
using Xunit;

namespace UserManagement.Application.User.Commands.UpdateUser.Tests
{
    public class UpdateUserHandlerTests
    {
        private readonly Mock<ILogger<UpdateUserHandler>> _loggerMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IGroupRepository> _groupRepositoryMock; 
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateUserHandler _handler;

        public UpdateUserHandlerTests()
        {
            _loggerMock = new Mock<ILogger<UpdateUserHandler>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _groupRepositoryMock = new Mock<IGroupRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new UpdateUserHandler(
                _userRepositoryMock.Object,
                _groupRepositoryMock.Object,
                _mapperMock.Object,
                _loggerMock.Object);
        }

        [Fact()]
        public async Task HandleUpdate_withValidRequest_ShouldUpdateUser()
        {
            // arrange
            var id = 1;
            var command = new UpdateUserRequest()
            {
                Id = id,
                Name = "Abram",
                Surname = "Mmako",
                Email = "chesa@gmail.com",
                ContactNumber = "0799610258",
                GroupIds = [1]
            };

            var user = new Domain.Entities.User()
            {
                Id = id,
                Name = "William",
                Email = "william@gmail.com",
                Surname = "Rakobela",
                ContactNumber = "0799610258"
            };


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

            _groupRepositoryMock.Setup(repo => repo.GetAllAsync())
                              .ReturnsAsync(groups);

            _userRepositoryMock.Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(user);


            // act
            await _handler.Handle(command, CancellationToken.None);

            // assert
            _userRepositoryMock.Verify(r => r.Update(user), Times.Once);
        }


        [Fact]
        public async Task HandleUpdate_WithNonExistingUser_ShouldThrowNotFoundException()
        {
            // Arrange
            var id = 2;
            var request = new UpdateUserRequest
            {
                Id = id
            };

            _userRepositoryMock.Setup(r => r.GetByIdAsync(id))
                    .ReturnsAsync((Domain.Entities.User?)null);

            // act

            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // assert
            await act.Should().ThrowAsync<NotFoundException>()
                    .WithMessage($"User with id: {id} doesn't exist");
        }
    }
}