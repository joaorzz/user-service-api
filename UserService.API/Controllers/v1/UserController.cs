using Application.Commands;
using Application.DTOs;
using Application.Queries;
using MediatR;
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
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Created(string.Empty, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            UsersResultDTO users = await _mediator.Send(new GetUserQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            UserDTO user = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(user);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            UserDTO user = await _mediator.Send(new GetUserByCpfQuery(cpf));

            return Ok(user);
        }
    }
}
