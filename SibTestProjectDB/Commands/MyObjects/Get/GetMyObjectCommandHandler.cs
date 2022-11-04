using MediatR;
using SibTestProjectDB.CoreTypes;
using SibTestProjectDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Get
{
    internal class GetMyObjectCommandHandler : IRequestHandler<GetMyObjectCommand, MyObject>
    {
        private readonly IMyObjectContext _dbContext;
        public GetMyObjectCommandHandler(IMyObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MyObject> Handle(GetMyObjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyObjects.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                return new MyObject();
            }

            return entity;
        }
    }
}
