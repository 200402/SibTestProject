using MediatR;
using SibTestProjectDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Delete
{
    internal class DeleteMyObjectCommandHandler : IRequestHandler<DeleteMyObjectCommand, int>
    {
        private readonly IMyObjectContext _dbContext;
        public DeleteMyObjectCommandHandler(IMyObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteMyObjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyObjects.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                return 404;
            }
            _dbContext.MyObjects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return 200;
        }
    }
}
