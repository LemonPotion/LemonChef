using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class RecipeCommentLike : CommentLike
{
    public Guid RecipeCommentId { get; set; }

    public RecipeComment RecipeComment { get; set; }

    public RecipeCommentLike()
    {
    }

    public RecipeCommentLike(Guid userId, Guid commentId) : base(userId, commentId)
    {
        RecipeCommentId = commentId;

        var validator = new RecipeCommentLikeValidator(nameof(RecipeCommentLike));
        validator.ValidateAndThrow(this);
    }
}