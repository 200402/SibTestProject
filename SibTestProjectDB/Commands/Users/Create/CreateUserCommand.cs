using MediatR;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
