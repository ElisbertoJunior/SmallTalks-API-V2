using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smalltalks.Models;

namespace Smalltalks.Data.Map
{
    public class SalutationMap : IEntityTypeConfiguration<SalutationModel>
    {
        public void Configure(EntityTypeBuilder<SalutationModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        }
    }
}
