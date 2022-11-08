using MediatR;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    public class GetUserByTokenCommand : IRequest<UserInfo>
    {
        public string Token { get; set; }
    }
}
