using MediatR;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Commands.Users.Get.UserList
{
    public class GetUserListCommand : IRequest<IList<User>>
    {
        public Guid Id { get; set; }
    }
}
