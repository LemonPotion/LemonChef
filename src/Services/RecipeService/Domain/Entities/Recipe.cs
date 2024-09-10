using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Recipe : BaseEntity
{
    public string Title { get; set; }
    
    public string? Link { get; set; }
    public ICollection<Ingredient>? Ingredients { get; set; }
    
    public int? PreparationTime { get; set; }
    
    public int? Servings { get; set; }
    
    public string Description { get; set; }
    
    public int? TelegramUserId { get; set; }

    public Recipe()
    {
        
    }
    public Recipe(Guid id,string title, string? link, ICollection<Ingredient>? ingredients, int? preparationTime, int? servings, string description, int? telegramUserId)
    {
        Id = id;
        Title = title;
        Link = link;
        Ingredients = ingredients;
        PreparationTime = preparationTime;
        Servings = servings;
        Description = description;
        TelegramUserId = telegramUserId;
        
        var validator = new RecipeValidator(nameof(Recipe));
        validator.ValidateAndThrow(this);
    }
}