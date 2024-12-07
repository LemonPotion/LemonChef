using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities.Base;

public class CommentLike : Like
{
    public Comment Comment { get; set; }

    public Guid CommentId { get; set; }

    public CommentLike()
    {
    }

    public CommentLike(Guid userId, Guid commentId) : base(userId)
    {
        CommentId = commentId;

        var validator = new CommentLikeValidator(nameof(CommentLike));
        validator.ValidateAndThrow(this);
    }
}