using MediatR;
using SibTestProjectDB.CoreTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Get
{
    internal class GetMyObjectCommand : IRequest<MyObject>
    {
        public Guid Id { get; set; }
    }
}
