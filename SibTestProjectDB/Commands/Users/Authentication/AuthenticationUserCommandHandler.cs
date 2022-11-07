using MediatR;
using SibTestProjectDB.TypesCore;
using SibTestProjectDB.Interfaces;
using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Authentication
{
    internal class AuthenticationUserCommandHandler : IRequestHandler<AuthenticationUserCommand, UserToken>
    {
        private readonly IUserContext _dbContext;
        public AuthenticationUserCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserToken> Handle(AuthenticationUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == request.Email && user.Password == request.Password);

            if (entity == null)
            {
                return new UserToken();
            }
            return new UserToken { Token = entity.Token };
        }
    }
}
