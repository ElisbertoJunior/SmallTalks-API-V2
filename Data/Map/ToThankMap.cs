using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smalltalks.Models;

namespace Smalltalks.Data.Map
{
    public class ToThankMap : IEntityTypeConfiguration<ToThankModel>
    {
        public void Configure(EntityTypeBuilder<ToThankModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        }
    }
}
