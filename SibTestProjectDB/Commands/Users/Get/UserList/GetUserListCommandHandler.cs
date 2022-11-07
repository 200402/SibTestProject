using MediatR;
using SibTestProjectDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibTestProjectDB.TypesCore;
using Microsoft.EntityFrameworkCore;

namespace SibTestProjectDB.Commands.Users.Get.UserList
{
    internal class GetUserListCommandHandler : IRequestHandler<GetUserListCommand, IList<User>>
    {
        private readonly IUserContext _dbContext;
        public GetUserListCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<User>> Handle(GetUserListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.Where(user => user.Id == request.Id).ToListAsync(cancellationToken);
            if (entity == null)
            {
                return new List<User>();
            }

            return entity;
        }
    }
}
