using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Domain.Exceptions;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Commands.DeleteUser
{
    public class DeleteUserHandler(IUserRepository userRepository, ILogger<DeleteUserHandler> logger) : IRequestHandler<DeleteUserRequest>
    {
        public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
            var user = await userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException(nameof(UserManagement.Domain.Entities.User), request.Id.ToString());
            }

            await userRepository.Delete(user);
        }
    }
}
