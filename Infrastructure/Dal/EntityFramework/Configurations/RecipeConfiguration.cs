using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id)
            .HasName("recipe_id");

        builder.HasIndex(r => new { r.PreparationTime, r.Servings, r.Title, r.Link, r.Description,
                TelegramId = r.TelegramUserId })
            .IsUnique()
            .HasDatabaseName("idx_recipe_prep_time_servings_title_link_desc_telegram_id");
        
        builder.HasIndex(r => r.TelegramUserId)
            .HasDatabaseName("idx_telegram_user_id");
        
        builder.Property(r => r.CreationDate)
            .IsRequired()
            .HasColumnName("date_created");

        builder.Property(r => r.ModifiedDate)
            .HasColumnName("date_modified");
        
        builder.Property(r => r.Title)
            .IsRequired()
            .HasColumnName("title");
        
        builder.Property(r => r.Link)
            .HasColumnName("link");
        
        builder.Property(r => r.Description)
            .IsRequired()
            .HasColumnName("description");
        
        builder.Property(r => r.PreparationTime)
            .HasColumnName("preparation_time_minutes");
        
        builder.Property(r => r.Servings)
            .HasColumnName("servings_count");

        builder.Property(r => r.TelegramUserId)
            .HasColumnName("telegram_user_id");
        
        builder.HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i=> i.RecipeId)
            .HasConstraintName("recipe_id");
    }
}