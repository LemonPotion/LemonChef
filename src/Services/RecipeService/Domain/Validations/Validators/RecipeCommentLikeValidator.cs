using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeCommentLikeValidator : AbstractValidator<RecipeCommentLike>
{
    public RecipeCommentLikeValidator(string paramName)
    {
        Include(new CommentLikeValidator(nameof(RecipeCommentLike)));

        RuleFor(param => param.RecipeCommentId)
            .NotNullOrEmptyWithMessage(nameof(RecipeCommentLike.RecipeCommentId));
    }
}