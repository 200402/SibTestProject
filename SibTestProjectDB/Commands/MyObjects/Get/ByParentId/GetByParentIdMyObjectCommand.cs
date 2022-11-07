using MediatR;
using SibTestProjectDB.TypesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Get.ByParentId
{
    internal class GetByParentIdMyObjectCommand : IRequest<MyObject>
    {
        public Guid ParentId { get; set; }
    }
}
