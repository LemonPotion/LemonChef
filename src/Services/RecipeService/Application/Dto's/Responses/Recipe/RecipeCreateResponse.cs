using Application.Dto_s.Responses.Ingredient;

namespace Application.Dto_s.Responses.Recipe;

public class RecipeCreateResponse : BaseRecipeDto
{
    public Guid Id { get; set; }
    
    public ICollection<IngredientGetResponse>? Ingredients { get; set; }
}