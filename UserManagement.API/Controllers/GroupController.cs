using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Group.Dtos;
using UserManagement.Application.Group.Queries.GetAllGroups;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetGroupList")]
        public async Task<IActionResult> GetGroupList()
        {
            return Ok(await mediator.Send(new GetAllGroupsQuery()));
        }

        [HttpGet("GetGroupsUserCount")]
        public async Task<IActionResult> GetGroupsUserCount()
        {
            return Ok(await mediator.Send(new GroupUserCountDto()));
        }
    }
}
