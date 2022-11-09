using MediatR;

namespace SibTestProjectDB.Commands.MyObjects.Create
{
    public class CreateMyObjectCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; } 
        public string Type { get; set; } 
        public int NestingLevel { get; set; }
        public ulong Size { get; set; } 
    }
}
