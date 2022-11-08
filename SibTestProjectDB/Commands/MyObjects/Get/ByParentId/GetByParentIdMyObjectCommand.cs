using MediatR;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Commands.MyObjects.Get.ByParentId
{
    internal class GetByParentIdMyObjectCommand : IRequest<MyObject>
    {
        public Guid ParentId { get; set; }
    }
}
