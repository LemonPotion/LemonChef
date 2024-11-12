using Domain.Entities.Base;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class RecipeLike : Like
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public RecipeLike()
    {
    }

    public RecipeLike(Guid userId, Guid recipeId) : base(userId)
    {
        RecipeId = recipeId;

        var validator = new RecipeLikeValidator(nameof(RecipeLike));
        validator.ValidateAndThrow(this);
    }
}