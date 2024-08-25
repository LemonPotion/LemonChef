namespace Domain.Entities;

public class Recipe : BaseEntity
{
    public string Title { get; set; }
    public Uri Link { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public int? PreparationTime { get; set; }
    public int? Servings { get; set; }
}