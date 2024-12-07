using Domain.Entities.Base;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class RecipeCommentLike : CommentLike
{
    public RecipeCommentLike()
    {
    }

    public RecipeCommentLike(Guid userId, Guid commentId) : base(userId, commentId)
    {
        CommentId = commentId;

        var validator = new RecipeCommentLikeValidator(nameof(RecipeCommentLike));
        validator.ValidateAndThrow(this);
    }
}