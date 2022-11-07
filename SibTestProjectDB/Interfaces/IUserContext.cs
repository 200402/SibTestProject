using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Interfaces
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
