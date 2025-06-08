using MediatR;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.User.Queries.GetUserCount
{
    public class GetUserCountHandler(IUserRepository userRepository) : IRequestHandler<GetUserCountQuery, int>
    {
        public async Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return users == null ? 0 : users.Count();
        }
    }
}
