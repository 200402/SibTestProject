using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibTestProjectDB.Commands.Users.Get.UserList;
using SibTestProjectDB.Commands.Users.Get.ByToken;
using SibTestProjectDB.Commands.Users.Create;
using SibTestProjectDB.Commands.Users.Authentication;
using SibTestProjectDB.TypesCore;
using System.Security.Claims;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private IMediator _med;
        protected IMediator Mediator => _med ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var query = new GetUserListCommand
            {
                Id = id,
            }; 
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("signUp/{login}/{password}")]
        public async Task<ActionResult<User>> signIn(string login, string password)
        {
            var query = new CreateUserCommand
            {
                Email = login,
                Password = password
            };
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("signIn/{login}/{password}")]
        public async Task<ActionResult<string>> signUp(string login, string password)
        {
            var query = new AuthenticationUserCommand
            {
                Email = login,
                Password = password
            }; 
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("getByToken/{login}")]
        public async Task<ActionResult<UserInfo>> getByToken(string token)
        {
            var query = new GetUserByTokenCommand
            {
                Token = token
            }; 
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("getByLogin/{login}")]
        public async Task<ActionResult<UserInfo>> getByLogin(string login)
        {
            var query = new GetUserByLoginCommand
            {
                Login = login
            }; 
            return Ok(await Mediator.Send(query));
        }
    }
}