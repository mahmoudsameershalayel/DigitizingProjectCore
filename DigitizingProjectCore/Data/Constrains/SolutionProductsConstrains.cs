using DigitizingProjectCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizingProjectCore.Data.Constrains
{
    public class SolutionProductsConstrains : IEntityTypeConfiguration<SolutionProducts>
    {
        public void Configure(EntityTypeBuilder<SolutionProducts> builder)
        {
            builder.HasOne(x => x.Product)
               .WithMany(x => x.SolutionProducts)
               .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Solution)
                .WithMany(x => x.SolutionProducts)
                .HasForeignKey(x => x.SolutionId);
        }
    }
}
