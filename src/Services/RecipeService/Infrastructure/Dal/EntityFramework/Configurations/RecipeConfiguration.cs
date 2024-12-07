using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => new
            {
                r.PreparationTime, r.Servings, r.Title, r.Link, r.Description
            })
            .IsUnique();

        builder.Property(c => c.CreatedOn)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(c => c.ModifiedOn);

        builder.Property(r => r.Title)
            .IsRequired();

        builder.Property(r => r.Link);

        builder.Property(r => r.Description);

        builder.Property(r => r.PreparationTime);

        builder.Property(r => r.Servings);

        builder.Property(r => r.CommentCount);

        builder.Property(r => r.LikeCount);

        builder.Property(r => r.ViewCount);

        builder.HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.UserId);

        builder.HasMany(r => r.Files)
            .WithOne(f => f.Recipe)
            .HasForeignKey(f => f.RecipeId);

        builder.HasMany(r => r.RecipeComments)
            .WithOne(f => f.Recipe)
            .HasForeignKey(f => f.RecipeId);

        builder.HasMany(r => r.Likes)
            .WithOne(l => l.Recipe)
            .HasForeignKey(l => l.RecipeId);
    }
}