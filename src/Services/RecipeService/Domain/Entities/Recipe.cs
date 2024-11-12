using Domain.Entities.Base;
using Domain.Interfaces;
using Domain.Validations.Validators;
using FluentValidation;

namespace Domain.Entities;

public class Recipe : BaseEntity, ITrackable, ILikeable, IViewable, ICommentable
{
    public string Title { get; set; }

    /// <summary>
    /// Ссылка на сторонний ресурс (например YouTube)
    /// </summary>
    public string? Link { get; set; }

    public int? PreparationTime { get; set; }

    public int? Servings { get; set; }

    public string Description { get; set; }

    public User? User { get; set; }
    public Guid? UserId { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? ModifiedOn { get; set; }

    public ICollection<Ingredient>? Ingredients { get; set; }

    public ICollection<RecipeLike>? Likes { get; set; }

    public ICollection<RecipeComment>? Comments { get; set; }

    public ICollection<RecipeFile>? Files { get; set; }

    public long ViewCount { get; set; }

    public long LikeCount { get; set; }

    public long CommentCount { get; set; }

    public Recipe()
    {
    }

    public Recipe(string title, string? link, int? preparationTime,
        int? servings, string description)
    {
        Title = title;
        Link = link;
        PreparationTime = preparationTime;
        Servings = servings;
        Description = description;

        var validator = new RecipeValidator(nameof(Recipe));
        validator.ValidateAndThrow(this);
    }
}