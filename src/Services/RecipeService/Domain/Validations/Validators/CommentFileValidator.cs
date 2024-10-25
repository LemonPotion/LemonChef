using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CommentFileValidator : AbstractValidator<CommentFile>
{
    public CommentFileValidator(string paramName)
    {
        Include(new LemonChefFileValidator(nameof(CommentFileValidator)));
        
        RuleFor(param => param.CommentId)
            .NotNullOrEmptyWithMessage(nameof(CommentFile.CommentId));
    }
}