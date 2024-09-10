using Domain.Validations.Primitives;
using FluentValidation;

namespace Domain.Validations;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> NotNullOrEmptyWithMessage<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, 
        string paramName)
    {
        return ruleBuilder
            .NotNull().WithMessage(ExceptionMessages.NullException(paramName))
            .NotEmpty().WithMessage(ExceptionMessages.EmptyException(paramName));
    }
    
    public static IRuleBuilderOptions<T, string?> IsValidUrlWithMessage<T>(
        this IRuleBuilder<T, string?> ruleBuilder, 
        string paramName)
    {
        return ruleBuilder
            .Must(param => Uri.IsWellFormedUriString(param, UriKind.Absolute))
            .WithMessage(ExceptionMessages.InvalidFormat(paramName));
    }
}