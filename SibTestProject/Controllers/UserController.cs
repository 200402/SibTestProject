using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibTestProjectDB.Commands.Users.Get.UserList;
using SibTestProjectDB.Commands.Users.Get.ByToken;
using SibTestProjectDB.Commands.Users.Create;
using SibTestProjectDB.Commands.Users.Authentication;
using SibTestProjectDB.TypesCore;
using System.Security.Claims;

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
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("signUp/{login}/{password}")]
        public async Task<ActionResult<User>> sign_in(string login, string password)
        {
            var query = new CreateUserCommand
            {
                Email = login,
                Password = password
            };
            return Ok(await Mediator.Send(query));
        }


        [HttpGet("signIn/{login}/{password}")]
        public async Task<ActionResult<string>> sign_up(string login, string password)
        {
            var query = new AuthenticationUserCommand
            {
                Email = login,
                Password = password
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}