using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeLikeConfiguration : IEntityTypeConfiguration<RecipeLike>
{
    public void Configure(EntityTypeBuilder<RecipeLike> builder)
    {
        builder.HasIndex(l => new
            {
                l.UserId, l.RecipeId
            })
            .IsUnique();

        builder.HasOne(l => l.Recipe)
            .WithMany(r => r.Likes)
            .HasForeignKey(r => r.RecipeId);
    }
}