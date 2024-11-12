using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeCommentLikeConfiguration : IEntityTypeConfiguration<RecipeCommentLike>
{
    public void Configure(EntityTypeBuilder<RecipeCommentLike> builder)
    {
        builder.HasIndex(l => new
            {
                l.UserId, l.RecipeCommentId
            })
            .IsUnique();

        builder.HasOne(l => l.RecipeComment)
            .WithMany(c => c.RecipeCommentLikes)
            .HasForeignKey(c => c.RecipeCommentId);
    }
}