using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.CreationDate)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.UpdateDate)
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate();

        builder.Property(x => x.Unit)
            .HasConversion<string>();

        builder.Property(x => x.Quantity);

        builder.HasOne(x => x.Ingredient)
            .WithMany().IsRequired();

        builder.HasOne(x => x.Recipe)
            .WithMany().IsRequired();

    }
}