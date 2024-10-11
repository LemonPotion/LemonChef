using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Recipe : BaseEntity, ITrackable, IRateable
{
    public string Title { get; set; }

    public string? Link { get; set; }

    public int? PreparationTime { get; set; }

    public int? Servings { get; set; }

    public string Description { get; set; }

    public int? TelegramUserId { get; set; }

    public User? User { get; set; }
    public Guid? UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Ingredient>? Ingredients { get; set; }

    public Recipe()
    {
    }

    //TODO: добавить новые поля в конструктор
    public Recipe(Guid id, string title, string? link, ICollection<Ingredient>? ingredients, int? preparationTime,
        int? servings, string description, int? telegramUserId, Guid? userId)
    {
        Id = id;
        Title = title;
        Link = link;
        Ingredients = ingredients;
        PreparationTime = preparationTime;
        Servings = servings;
        Description = description;
        TelegramUserId = telegramUserId;
        UserId = userId;

        var validator = new RecipeValidator(nameof(Recipe));
        validator.ValidateAndThrow(this);
    }

    public long ViewCount { get; set; }
    public long LikeCount { get; set; }
    public long CommentCount { get; set; }
    public long ShareCount { get; set; }
}