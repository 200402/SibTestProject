using MediatR;
using SibTestProjectDB.TypesCore;
using SibTestProjectDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Create
{
    internal class CreateMyObjectCommandHandler : IRequestHandler<CreateMyObjectCommand, Guid>
    {
        private readonly IMyObjectContext _dbContext;
        public CreateMyObjectCommandHandler(IMyObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateMyObjectCommand request, CancellationToken cancellationToken)
        {
            var obj = new MyObject
            {
                UserId = request.UserId,
                Name = request.Name,
                ParentId = request.ParentId,
                Type = request.Type,
                CreationDate = DateTime.Now,
                Size = request.Size
            };
            await _dbContext.MyObjects.AddAsync(obj, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return obj.Id;
        }
    }
}
