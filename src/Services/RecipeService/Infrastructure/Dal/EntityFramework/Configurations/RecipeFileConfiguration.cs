using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeFileConfiguration : IEntityTypeConfiguration<RecipeFile>
{
    public void Configure(EntityTypeBuilder<RecipeFile> builder)
    {
        builder.HasOne(f => f.Recipe)
            .WithMany(r => r.Files)
            .HasForeignKey(f => f.RecipeId);
    }
}