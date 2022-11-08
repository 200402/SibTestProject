using MediatR;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Commands.MyObjects.Get.ById
{
    internal class GetByIdMyObjectCommand : IRequest<MyObject>
    {
        public Guid Id { get; set; }
    }
}
