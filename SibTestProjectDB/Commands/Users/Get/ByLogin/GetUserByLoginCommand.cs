using MediatR;
using SibTestProjectDB.TypesCore;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    public class GetUserByLoginCommand : IRequest<UserInfo>
    {
        public string Login { get; set; }
    }
}
