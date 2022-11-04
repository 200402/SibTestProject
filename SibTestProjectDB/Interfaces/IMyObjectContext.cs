using Microsoft.EntityFrameworkCore;
using SibTestProjectDB.CoreTypes;

namespace SibTestProjectDB.Interfaces
{
    internal interface IMyObjectContext
    {
        DbSet<MyObject> MyObjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
