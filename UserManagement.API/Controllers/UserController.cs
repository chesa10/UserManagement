using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.User.Commands.AddUser;
using UserManagement.Application.User.Commands.DeleteUser;
using UserManagement.Application.User.Commands.UpdateUser;
using UserManagement.Application.User.Queries.GetAllUsers;
using UserManagement.Application.User.Queries.GetUserById;
using UserManagement.Application.User.Queries.GetUserCount;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest userRequest)
        {
            return Ok(await mediator.Send(userRequest));
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            return Ok(await mediator.Send(updateUserRequest));
        }

        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList()
        {
            return Ok(await mediator.Send(new GetAllUsersQuery()));
        }

        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await mediator.Send(new DeleteUserRequest() { Id = id });
            return NoContent();
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            return Ok(await mediator.Send(new GetUserByIdQuery() { Id = id }));
        }

        [HttpGet("GetUserCount")]
        public async Task<IActionResult> GetUserCount()
        {
            return Ok(await mediator.Send(new GetUserCountQuery()));
        }
    }
}
