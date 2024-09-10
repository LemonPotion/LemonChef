using Domain.Entities;
using Domain.Validations.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient> 
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(i => i.Id)
            .HasName("ingredient_id");
        
        builder.Property(r => r.CreatedOn)
            .IsRequired()
            .HasColumnName("date_created");

        builder.Property(r => r.ModifiedOn)
            .HasColumnName("date_modified");
        
        builder.Property(i => i.Name)
            .IsRequired()
            .HasColumnName("name");
        //TODO: никто не захочет выбирать цифрами меру , сделать конверсию из string в enum и наоборот на уровне запросов
        builder.Property(i => i.Unit)
            .HasConversion<string>()
            .HasDefaultValue(UnitsOfMeasure.Gram)
            .HasColumnName("measure_unit");

        builder.Property(i => i.Quantity)
            .HasColumnName("quantity");

        builder.HasOne(i => i.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(i => i.RecipeId)
            .IsRequired()
            .HasConstraintName("recipe_id");
    }
}