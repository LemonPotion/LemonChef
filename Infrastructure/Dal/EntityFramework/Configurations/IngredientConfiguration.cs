using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient> 
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Name)
            .IsUnique();
        
        builder.Property(x => x.CreationDate)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.UpdateDate)
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate();
        
        builder.Property(x => x.Name)
            .IsRequired();
    }
}