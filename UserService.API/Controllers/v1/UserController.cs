using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Created(string.Empty, null);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            UsersResultDTO users = await _mediator.Send(new GetUserQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            UserDTO user = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(user);
        }

        [HttpGet("cpf/{cpf}")]
        [Authorize]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            UserDTO user = await _mediator.Send(new GetUserByCpfQuery(cpf));

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteUserCommand deleteUserCommand = new DeleteUserCommand(id);

            await _mediator.Send(deleteUserCommand);

            return NoContent();
        }
    }
}
