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

    public CommentFile(Guid userId, Guid commentId, string originalName, string googleDriveName) : base(userId, googleDriveName)
    {
        CommentId = commentId;
        OriginalName = originalName;

        //TODO: перенести всю валидацию на уровень Application, будет меньше конструкторов
        var validator = new CommentFileValidator(nameof(CommentFile));
        validator.ValidateAndThrow(this);
    }
}