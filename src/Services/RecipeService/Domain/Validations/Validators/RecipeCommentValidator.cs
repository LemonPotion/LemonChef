using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeCommentValidator : AbstractValidator<RecipeComment>
{
    public RecipeCommentValidator(string paramName)
    {
        Include(new CommentValidator(nameof(RecipeComment)));

        RuleFor(param => param.RecipeId)
            .NotNullOrEmptyWithMessage(nameof(RecipeLike.RecipeId));
    }
}