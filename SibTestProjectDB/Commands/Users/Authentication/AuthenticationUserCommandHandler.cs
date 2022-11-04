using MediatR;
using SibTestProjectDB.CoreTypes;
using SibTestProjectDB.Interfaces;

namespace SibTestProjectDB.Commands.Users.Authentication
{
    internal class AuthenticationUserCommandHandler : IRequestHandler<AuthenticationUserCommand, string>
    {
        private readonly IUserContext _dbContext;
        public AuthenticationUserCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(AuthenticationUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(new object[] { request.Email,request.Password }, cancellationToken);

            if (entity == null)
            {
                return "403";
            }
            return entity.Token;
        }
    }
}
