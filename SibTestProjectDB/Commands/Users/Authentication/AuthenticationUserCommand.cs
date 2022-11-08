using MediatR;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Authentication
{
    public class AuthenticationUserCommand : IRequest<UserToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
