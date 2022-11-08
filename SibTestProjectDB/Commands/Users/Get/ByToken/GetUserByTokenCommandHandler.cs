using MediatR;
using SibTestProjectDB.Interfaces;
using SibTestProjectDB.TypesCore;
using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesIntermediate;

namespace SibTestProjectDB.Commands.Users.Get.ByToken
{
    internal class GetUserByTokenCommandHandler : IRequestHandler<GetUserByTokenCommand, UserInfo>
    {
        private readonly IUserContext _dbContext;
        public GetUserByTokenCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserInfo> Handle(GetUserByTokenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Token == request.Token);
            if (entity == null)
            {
                return new UserInfo {Login =  "nothing" };
            }

            return new UserInfo { Login = entity.Email, FreeSpace = entity.FreeSpace, SizeOfTheAvailableStorage = entity.SizeOfTheAvailableStorage };
        }
    }
}
