using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SibTestProjectDB.CoreTypes;
using SibTestProjectDB.Interfaces;
using SibTestProjectDB.Commands.Users;


namespace SibTestProjectDB.Commands.Users.Create
{
    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserContext _dbContext;
        public CreateUserCommandHandler(IUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                Token = GenerateRandomString(50, 70) //TODO заменить этот шлак на чет адекватное (ну или забей, JWT тут не нужОн)
            };
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Token;
        }

        private string GenerateRandomString(int minLenght, int maxLenght)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars += chars.ToLower() + "0123456789";
            var r = new Random();
            return "test_" + new string(Enumerable.Repeat(chars, r.Next(minLenght, maxLenght))
                    .Select(s => s[r.Next(s.Length)]).ToArray());
        }
    }
}
