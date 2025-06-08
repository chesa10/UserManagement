using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Application.User.Dtos;
using UserManagement.Application.User.Queries.GetAllUsers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Queries.GetUserById
{
    internal class GetUserByIdHandler(IUserRepository userRepository,
                                                 ILogger<GetAllUsersHandler> logger,
                                                 IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting user by Id");
            var users = await userRepository.GetByIdAsync(request.Id);

            var userDto = mapper.Map<UserDto>(users);

            return userDto;
        }
    }
}
