using MediatR;
using SibTestProjectDB.TypesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Get.ById
{
    internal class GetByIdMyObjectCommand : IRequest<MyObject>
    {
        public Guid Id { get; set; }
    }
}
