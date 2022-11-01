using Microsoft.AspNetCore.Mvc;

namespace SibTestProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("123")]
        public void Get()
        {

        }
    }
}