using MediatR;

namespace SibTestProjectDB.Commands.MyObjects.Delete
{
    internal class DeleteMyObjectCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
