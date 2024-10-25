using Domain.Entities;
using Domain.Validations.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(c => c.CreatedOn)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(c => c.ModifiedOn)
            .ValueGeneratedOnUpdate();

        builder.Property(i => i.Name)
            .IsRequired();

        builder.Property(i => i.Unit)
            .HasConversion<int>()
            .HasDefaultValue(UnitsOfMeasure.Gram);

        builder.Property(i => i.Quantity);

        builder.HasOne(i => i.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(i => i.RecipeId)
            .IsRequired();
    }
}