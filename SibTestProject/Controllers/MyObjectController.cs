using MediatR;
using Microsoft.AspNetCore.Mvc;
using FileManager;
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
    [Route("apiObj")]
    public class MyObjectController : ControllerBase
    {
        private IMediator _med;
        protected IMediator Mediator => _med ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            return id;
        }
    }
}