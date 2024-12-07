using Domain.Entities;
using Domain.Entities.Base;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CommentLikeValidator : AbstractValidator<CommentLike>
{
    public CommentLikeValidator(string paramName)
    {
        Include(new LikeValidator(nameof(CommentLike)));

        RuleFor(param => param.CommentId)
            .NotNullOrEmptyWithMessage(nameof(CommentLike.CommentId));
    }
}