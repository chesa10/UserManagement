using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserManagement.Application.Group.Dtos;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Group.Queries.GetAllGroups
{
    public class GetAllGroupsHandler(IGroupRepository groupRepository, ILogger<GetAllGroupsHandler> logger, IMapper mapper) : IRequestHandler<GetAllGroupsQuery, IEnumerable<GroupDto>>
    {
        public async Task<IEnumerable<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all groups");
            var groups = await groupRepository.GetAllAsync();
            var groupDto = mapper.Map<IEnumerable<GroupDto>>(groups);

            return groupDto;
        }
    }
}
