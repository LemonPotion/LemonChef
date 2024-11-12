using Domain.Entities.Base;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class CommentFile : LemonChefFile
{
    public Guid CommentId { get; set; }

    public Comment Comment { get; set; }

    public CommentFile()
    {
    }

    public CommentFile(Guid userId, Guid commentId, string fileName, string filePath, string fileFormat,
        int fileSizeInBytes, long? duration) : base(userId, fileName, filePath, fileFormat, fileSizeInBytes, duration)
    {
        CommentId = commentId;

        //TODO: перенести всю валидацию на уровень Application
        var validator = new CommentFileValidator(nameof(CommentFile));
        validator.ValidateAndThrow(this);
    }
}