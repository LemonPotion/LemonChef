using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    //TODO:  проверить отношения таблиц
namespace Infrastructure.Dal.EntityFramework.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.PreparationTime, x.Servings, x.Title, x.Link })
            .IsUnique();
        
        builder.Property(x => x.CreationDate)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.UpdateDate)
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate();
        
        builder.Property(x => x.Title)
            .IsRequired();
        
        builder.Property(x => x.Link)
            .IsRequired();
        
        builder.Property(x => x.PreparationTime);
        
        builder.Property(x => x.Servings);
        
        builder.HasMany(x => x.Ingredients)
            .WithOne()
            .IsRequired();
    }
}