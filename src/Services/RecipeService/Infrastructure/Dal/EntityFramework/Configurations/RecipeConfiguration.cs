using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => new
            {
                r.PreparationTime, r.Servings, r.Title, r.Link, r.Description,
                TelegramId = r.TelegramUserId
            })
            .IsUnique();

        builder.HasIndex(r => r.TelegramUserId);

        builder.Property(r => r.CreatedOn)
            .IsRequired();

        builder.Property(r => r.ModifiedOn);

        builder.Property(r => r.Title)
            .IsRequired();

        builder.Property(r => r.Link);
        
        builder.Property(r => r.Description)
            .IsRequired();
        
        builder.Property(r => r.PreparationTime);
        
        builder.Property(r => r.Servings);

        builder.Property(r => r.TelegramUserId);
        
        builder.HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i=> i.RecipeId);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.UserId);
    }
}