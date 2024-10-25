using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CreatedOn)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.ModifiedOn)
            .ValueGeneratedOnUpdate();

        builder.Property(c => c.Text)
            .HasMaxLength(10000);

        builder.HasDiscriminator<string>("comment_type_discriminator")
            .HasValue<RecipeComment>(nameof(RecipeComment))
            .HasValue<Comment>(nameof(Comment));

        builder.HasMany(c => c.Files)
            .WithOne(f => f.Comment)
            .HasForeignKey(f => f.CommentId);

        builder.HasMany(c => c.Likes)
            .WithOne(l => l.Comment)
            .HasForeignKey(l => l.CommentId);
    }
}