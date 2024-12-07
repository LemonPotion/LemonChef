﻿using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators;

public class IngredientValidator : AbstractValidator<Ingredient>
{
    public IngredientValidator(string paramName)
    {
        RuleFor(param => param.Name)
            .NotNullOrEmptyWithMessage(nameof(Ingredient.Name))
            .Length(2, 250)
            .WithMessage(ExceptionMessages.InvalidFormat(nameof(Ingredient.Name)));

        RuleFor(param => param.Quantity)
            .GreaterThan(0)
            .WithMessage(ExceptionMessages.TooLowNumber(nameof(Ingredient.Quantity)));

        RuleFor(param => param.Unit)
            .IsInEnum()
            .When(param => param.Unit is not null)
            .WithMessage(ExceptionMessages.InvalidEnumValue(nameof(Ingredient.Unit)));

        RuleFor(param => param.RecipeId)
            .NotNullOrEmptyWithMessage(nameof(Ingredient.RecipeId));
    }
}