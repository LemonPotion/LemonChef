using Domain.Interfaces;
using Domain.Validations.Primitives;

namespace Domain.Entities.Base;

public class LemonChefFile : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; }

    public string FileName { get; set; }

    public string FilePath { get; set; }

    public FileFormats FileFormat { get; set; }

    public int FileSizeInBytes { get; set; }

    public long? Duration { get; set; }
}