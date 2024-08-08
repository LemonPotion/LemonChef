using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class BaseEntityValidator<T> : AbstractValidator<T> where T : BaseEntity
{
    public BaseEntityValidator(string paramName)
    {
        RuleFor(param => param.UpdateDate)
            .NotNullOrEmptyWithMessage(paramName);
        RuleFor(param => param.CreationDate)
            .NotNullOrEmptyWithMessage(paramName);
    }
}