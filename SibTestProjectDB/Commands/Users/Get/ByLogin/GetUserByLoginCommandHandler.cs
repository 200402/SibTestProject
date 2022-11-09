using MediatR;
using SibTestProjectDB.Interfaces;
using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    internal class GetUserByLoginCommandHandler : IRequestHandler<GetUserByLoginCommand, UserInfo>
    {
        private readonly IUserContext _dbContext;
        public GetUserByLoginCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserInfo> Handle(GetUserByLoginCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Login == request.Login);
            if (entity == null)
            {
                return new UserInfo { Login = "nothing"};
            }

            return new UserInfo { Login = entity.Login, FreeSpace = entity.FreeSpace, SizeOfTheAvailableStorage = entity.SizeOfTheAvailableStorage};
        }
    }
}
