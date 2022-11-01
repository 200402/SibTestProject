using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.Data.CoreTypes;

namespace SibTestProjectDB.Interfaces
{
    internal interface IUserContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
