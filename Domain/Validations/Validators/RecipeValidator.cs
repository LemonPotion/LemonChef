using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators;

public class RecipeValidator : AbstractValidator<Recipe>
{
    public RecipeValidator(string paramName)
    {
        Include(new BaseEntityValidator<Recipe>(paramName));

        RuleFor(param => param.Title)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleFor(param => param.Link)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleForEach(param => param.Ingredients)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleFor(param => param.Hash)
            .NotNullOrEmptyWithMessage(paramName);
        
        RuleFor(param=> param.Servings)
            .NotEmptyIfNotNullWithMessage(paramName);
        
        RuleFor(param=>param.PreparationTime)
            .NotEmptyIfNotNullWithMessage(paramName);
    }
}