using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Primitives;
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

    public CommentFile(Guid userId, Guid commentId, string fileName, string filePath, FileFormats fileFormat, int fileSizeInBytes, long? duration) : base(userId, fileName, filePath, fileFormat, fileSizeInBytes, duration)
    {
        CommentId = commentId;
        
        var validator = new CommentFileValidator(nameof(CommentFile));
        validator.ValidateAndThrow(this);
    }
}