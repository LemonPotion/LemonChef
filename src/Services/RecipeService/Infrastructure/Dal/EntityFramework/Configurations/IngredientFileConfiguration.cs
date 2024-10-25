using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class IngredientFileConfiguration : IEntityTypeConfiguration<IngredientFile>
{
    public void Configure(EntityTypeBuilder<IngredientFile> builder)
    {
        builder.HasOne(f => f.Ingredient)
            .WithMany(r => r.Files)
            .HasForeignKey(f => f.IngredientId);
    }
}