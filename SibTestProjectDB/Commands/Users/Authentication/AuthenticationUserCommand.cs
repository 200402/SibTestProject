using MediatR;
using SibTestProjectDB.TypesCore;
using SibTestProjectDB.TypesIntermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.Users.Authentication
{
    public class AuthenticationUserCommand : IRequest<UserToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
