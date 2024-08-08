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

    public static IRuleBuilderOptions<T, TProperty> NotEmptyIfNotNullWithMessage<T, TProperty>(
        this IRuleBuilder<T,TProperty> ruleBuilder,
        string paramName)
    {
        return ruleBuilder.NotEmpty()
            .When(param=> param is not null)
            .WithMessage(ExceptionMessages.EmptyException(paramName));
    }
}