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

        builder.Property(r => r.CreatedOn)
            .IsRequired();


        builder.Property(r => r.ModifiedOn);


        builder.Property(i => i.Name)
            .IsRequired();

        //TODO: никто не захочет выбирать цифрами меру , сделать конверсию из string в enum и наоборот на уровне запросов
        builder.Property(i => i.Unit)
            .HasConversion<string>()
            .HasDefaultValue(UnitsOfMeasure.Gram);

        builder.Property(i => i.Quantity);

        builder.HasOne(i => i.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(i => i.RecipeId)
            .IsRequired();
    }
}