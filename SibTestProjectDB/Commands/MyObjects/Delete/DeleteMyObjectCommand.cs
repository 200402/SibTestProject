using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Delete
{
    internal class DeleteMyObjectCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
