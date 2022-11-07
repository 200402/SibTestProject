using MediatR;
using SibTestProjectDB.TypesCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.Users.Get.UserList
{
    public class GetUserListCommand : IRequest<IList<User>>
    {
        public Guid Id { get; set; }
    }
}
