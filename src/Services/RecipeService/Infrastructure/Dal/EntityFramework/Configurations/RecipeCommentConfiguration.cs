using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeCommentConfiguration : IEntityTypeConfiguration<RecipeComment>
{
    public void Configure(EntityTypeBuilder<RecipeComment> builder)
    {
        builder.Property(c => c.LikeCount);

        builder.HasOne(c => c.Recipe)
            .WithMany(r => r.RecipeComments)
            .HasForeignKey(c => c.RecipeId);
    }
}