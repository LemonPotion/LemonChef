using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class LemonChefFileConfigurations : IEntityTypeConfiguration<LemonChefFile>
{
    public void Configure(EntityTypeBuilder<LemonChefFile> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(f => f.GoogleDriveName)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        builder.Property(f => f.OriginalName)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);;

        builder.HasDiscriminator<string>("file_type_discriminator")
            .HasValue<LemonChefFile>(nameof(LemonChefFile))
            .HasValue<IngredientFile>(nameof(IngredientFile))
            .HasValue<RecipeFile>(nameof(RecipeFile));

        builder.HasOne<User>(f => f.User)
            .WithMany(u => u.UserFiles)
            .HasForeignKey(f => f.UserId);
    }
}