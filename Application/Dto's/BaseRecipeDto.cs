namespace Application.Dto_s;

public class BaseRecipeDto
{
    public string Title { get; set; }
    
    public Uri Link { get; set; }
    
    public ICollection<BaseIngredientDto> IngredientDtos { get; set; }
    
    public string Hash { get; set; }
    
    public int? PreparationTime { get; set; }
    
    public int? Servings { get; set; }
    
    public string Description { get; set; }
}