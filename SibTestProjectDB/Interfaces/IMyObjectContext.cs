using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.TypesCore;

namespace SibTestProjectDB.Interfaces
{
    public interface IMyObjectContext
    {
        DbSet<MyObject> MyObjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
