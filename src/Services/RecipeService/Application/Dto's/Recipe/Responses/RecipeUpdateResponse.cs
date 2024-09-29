using Application.Dto_s.Ingredient.Responses;

namespace Application.Dto_s.Recipe.Responses;

public class RecipeUpdateResponse : BaseRecipeDto
{
    public Guid Id { get; set; }
    public ICollection<IngredientGetResponse>? Ingredients { get; set; }
}