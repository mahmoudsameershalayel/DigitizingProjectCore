using Abp.DynamicEntityProperties;
using DigitizingProjectCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizingProjectCore.Data.Constrains
{
    public class AdminLinksConstrains : IEntityTypeConfiguration<AdminLinks>
    {
        public void Configure(EntityTypeBuilder<AdminLinks> builder)
        {
            builder.HasOne(x => x.Admin)
                .WithMany(x => x.AdminLinks)
                .HasForeignKey(x => x.AdminId);

            builder.HasOne(x => x.Link)
                .WithMany(x => x.AdminLinks)
                .HasForeignKey(x => x.LinkId);
        }
    }
}
