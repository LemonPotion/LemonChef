using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class CommentFileConfiguration : IEntityTypeConfiguration<CommentFile>
{
    public void Configure(EntityTypeBuilder<CommentFile> builder)
    {
        builder.HasOne(f => f.Comment)
            .WithMany(r => r.Files)
            .HasForeignKey(f => f.CommentId);
    }
}