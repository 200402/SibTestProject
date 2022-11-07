using MediatR;
using SibTestProjectDB.Interfaces;
using SibTestProjectDB.TypesCore;
using Microsoft.EntityFrameworkCore;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    internal class GetUserByTokenCommandHandler : IRequestHandler<GetUserByTokenCommand, User>
    {
        private readonly IUserContext _dbContext;
        public GetUserByTokenCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(GetUserByTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Token == request.Token);
            if (entity == null)
            {
                return new User();
            }

            return entity;
        }
    }
}
