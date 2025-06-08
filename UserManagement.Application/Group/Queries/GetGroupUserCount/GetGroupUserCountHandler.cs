using MediatR;
using UserManagement.Application.Group.Dtos;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Group.Queries.GetGroupUserCount
{
    public class GetGroupUserCountHandler(IGroupRepository groupRepository) : IRequestHandler<GroupUserCountDto, List<GroupUserCountDto>>
    {
        public async Task<List<GroupUserCountDto>> Handle(GroupUserCountDto request, CancellationToken cancellationToken)
        {
            var groupUserCount = new List<GroupUserCountDto>();
            var groups = await groupRepository.GetAllAsync();
            foreach (var group in groups)
            {
                groupUserCount.Add(
                    new GroupUserCountDto()
                    {
                        GroupName = group.Name,
                        UserCount = group.Users != null ? group.Users.Count : 0
                    }
                );
            }
            return groupUserCount;
        }
    }
}
