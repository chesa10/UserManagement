using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Domain.Exceptions;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Commands.UpdateUser
{
    public class UpdateUserHandler(IUserRepository userRepository, IGroupRepository groupRepository, IMapper mapper,
                                                 ILogger<UpdateUserHandler> logger) : IRequestHandler<UpdateUserRequest, bool>
    {
        public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating user");

            var groups = await groupRepository.GetAllAsync();
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(User), request.Id.ToString());

            mapper.Map(request, user);
            user.Groups = groups.Where(g => request.GroupIds.Contains(g.Id)).ToList();

            return await userRepository.Update(user);
        }
    }
}
