using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Commands.AddUser
{
    public class AddUserHandler(IUserRepository userRepository, IGroupRepository groupRepository, IMapper mapper,
                                                 ILogger<AddUserHandler> logger) : IRequestHandler<AddUserRequest, int>
    {
        public async Task<int> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding user");

            var user = mapper.Map<UserManagement.Domain.Entities.User>(request);
            var groups = await groupRepository.GetAllAsync();
            user.Groups = groups.Where(g => request.GroupIds.Contains(g.Id)).ToList();
            return await userRepository.Create(user);
        }
    }
}
