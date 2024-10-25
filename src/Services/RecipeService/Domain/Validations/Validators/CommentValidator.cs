using Domain.Entities.Base;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator(string paramName)
    {
        RuleFor(param => param.UserId)
            .NotNullOrEmptyWithMessage(nameof(Comment.UserId));

        RuleFor(param => param.Text)
            .NotNullOrEmptyWithMessage(nameof(Comment.Text))
            .Length(2, 2000);
    }
}