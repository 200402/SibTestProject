using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibTestProjectDB.Commands.Users.Get.UserList;
using SibTestProjectDB.Commands.Users.Create;
using SibTestProjectDB.CoreTypes;
using System.Security.Claims;

namespace SibTestProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private IMediator _med;
        protected IMediator Mediator => _med ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated ? Guid.Empty : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);


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
    }
}