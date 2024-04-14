using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smalltalks.Models;

namespace Smalltalks.Data.Map
{
    public class SwearingMap : IEntityTypeConfiguration<SwearingModel>
    {
        public void Configure(EntityTypeBuilder<SwearingModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        }
    }
}
