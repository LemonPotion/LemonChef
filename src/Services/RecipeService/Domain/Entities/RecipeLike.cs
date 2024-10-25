using Domain.Entities.Base;

namespace Domain.Entities;

public class RecipeLike : Like
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}