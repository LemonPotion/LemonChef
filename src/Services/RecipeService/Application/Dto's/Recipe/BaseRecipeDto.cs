namespace Application.Dto_s.Recipe;

public class BaseRecipeDto
{
    public string Title { get; set; }
    
    public string? Link { get; set; }
    
    public int? PreparationTime { get; set; }
    
    public int? Servings { get; set; }
    
    public string Description { get; set; }
 
    public int? TelegramUserId { get; set; }
    
    public Guid? UserId { get; set; }
}