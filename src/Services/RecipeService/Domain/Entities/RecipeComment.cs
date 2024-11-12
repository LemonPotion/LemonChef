using Domain.Entities.Base;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class RecipeComment : Comment
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public ICollection<RecipeCommentLike> RecipeCommentLikes { get; set; }

    public long LikeCount { get; set; }

    public RecipeComment()
    {
    }

    public RecipeComment(Guid userId, Guid recipeId, string text) : base(userId, text)
    {
        RecipeId = recipeId;

        var validator = new RecipeCommentValidator(nameof(RecipeComment));
        validator.ValidateAndThrow(this);
    }
}