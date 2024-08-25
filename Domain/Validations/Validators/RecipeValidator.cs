using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeValidator : AbstractValidator<Recipe>
{
    public RecipeValidator(string paramName)
    {
        Include(new BaseEntityValidator<Recipe>(paramName));

        RuleFor(param => param.Title)
            .NotNullOrEmptyWithMessage(paramName)
            .Length(1,250);
        
        RuleFor(param => param.Link)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleForEach(param => param.Ingredients)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleFor(param=> param.Servings)
            .NotEmptyIfNullableWithMessage(paramName)
            .GreaterThan(0);
        
        RuleFor(param=>param.PreparationTime)
            .NotEmptyIfNullableWithMessage(paramName)
            .GreaterThan(0);
    }
}