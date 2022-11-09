using MediatR;
using Microsoft.AspNetCore.Mvc;
using SibTestProjectDB.Commands.MyObjects.Create;
using FileManager;
using SibTestProjectDB.TypesCore;

namespace SibTestProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class MyObjectController : ControllerBase
    {
        private IMediator _med;
        protected IMediator Mediator => _med ??= HttpContext.RequestServices.GetService<IMediator>();
        private static readonly string[] Summaries = new[]
        {
        "folder", "file"
        };

        [HttpPost("createFile")]
        public async Task<ActionResult> createFile([FromBody] CreateMyObjectCommand createMyObject)
        {
            await Mediator.Send(createMyObject);
            return NoContent();
        }
        [HttpGet("getFiles")]
        public IEnumerable<MyObject> getFile()
        {
            return Enumerable.Range(1, 10).Select(index => new MyObject
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Name = index.ToString(),
                ParentId = Guid.NewGuid(),
                Type = Summaries[Random.Shared.Next(Summaries.Length)],
                CreationDate = DateTime.Now,
                NestingLevel = 0,
                Size = 0
            }).ToArray();
        }
    }
}