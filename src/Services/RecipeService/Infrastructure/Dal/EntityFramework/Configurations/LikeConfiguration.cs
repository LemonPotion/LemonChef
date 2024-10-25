using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(i => i.Id);

        builder.HasDiscriminator<string>("like_type_discriminator")
            .HasValue<Like>(nameof(Like))
            .HasValue<RecipeLike>(nameof(RecipeLike))
            .HasValue<RecipeCommentLike>(nameof(RecipeCommentLike));

        builder.HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId);
    }
}