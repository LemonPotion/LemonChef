using Domain.Entities.Base;
using FluentValidation;

namespace Domain.Validations.Validators;

public class LikeValidator : AbstractValidator<Like>
{
    public LikeValidator(string paramName)
    {
        RuleFor(param => param.UserId)
            .NotNullOrEmptyWithMessage(nameof(Like.UserId));
    }
}