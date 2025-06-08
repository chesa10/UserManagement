using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Application.User.Dtos;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Queries.GetAllUsers
{
    public class GetAllUsersHandler(IUserRepository userRepository,
                                                 ILogger<GetAllUsersHandler> logger,
                                                 IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all users");
            var users = await userRepository.GetAllAsync();

            var userDto = mapper.Map<IEnumerable<UserDto>>(users);

            return userDto;
        }
    }
}
