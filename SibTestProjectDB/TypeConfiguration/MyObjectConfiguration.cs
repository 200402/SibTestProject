using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibTestProjectDB.Data.CoreTypes;

namespace SibTestProjectDB.TypeConfiguration
{
    internal class MyObjectConfiguration : IEntityTypeConfiguration<MyObject>
    {
        public void Configure(EntityTypeBuilder<MyObject> builder)
        {
            builder.HasKey(MyObjectx => MyObjectx.Id);
            builder.HasIndex(MyObject => MyObject.Id).IsUnique();
        }
    }
}
