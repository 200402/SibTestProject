using MediatR;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    public class GetUserByTokenCommand : IRequest<User>
    {
        public string Token { get; set; }
    }
}
