using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities.Base;

public class LemonChefFile : BaseEntity
{
    //TODO: придумать ограничение по формату файла
    public Guid UserId { get; set; }

    public User User { get; set; }

    public string FileName { get; set; }

    public string FilePath { get; set; }

    public string FileFormat { get; set; }

    public long FileSizeInBytes { get; set; }

    public long? Duration { get; set; }

    public LemonChefFile()
    {
    }

    public LemonChefFile(Guid userId, string fileName, string filePath, string fileFormat, int fileSizeInBytes,
        long? duration)
    {
        UserId = userId;
        FileName = fileName;
        FilePath = filePath;
        FileFormat = fileFormat;
        FileSizeInBytes = fileSizeInBytes;
        Duration = duration;

        var validator = new LemonChefFileValidator(nameof(LemonChefFile));
        validator.ValidateAndThrow(this);
    }
}