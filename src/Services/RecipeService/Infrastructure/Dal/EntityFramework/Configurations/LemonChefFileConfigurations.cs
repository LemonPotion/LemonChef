using Domain.Entities;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

//TODO: проверить конфигурации
public class LemonChefFileConfigurations : IEntityTypeConfiguration<LemonChefFile>
{
    public void Configure(EntityTypeBuilder<LemonChefFile> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(f => f.FileName)
            .IsRequired()
            .HasMaxLength(255)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.FilePath)
            .IsRequired()
            .HasMaxLength(1024)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.FileFormat)
            .HasConversion<int>()
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(f => f.FileSizeInBytes)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(f => f.Duration)
            .ValueGeneratedOnAdd();

        builder.HasDiscriminator<string>("file_type_discriminator")
            .HasValue<LemonChefFile>(nameof(LemonChefFile))
            .HasValue<IngredientFile>(nameof(IngredientFile))
            .HasValue<RecipeFile>(nameof(RecipeFile))
            .HasValue<CommentFile>(nameof(CommentFile));

        builder.HasOne<User>(f => f.User)
            .WithMany(u => u.UserFiles)
            .HasForeignKey(f => f.UserId);
    }
}