namespace Domain.Entities;

public class Recipe : BaseEntity
{
    public string Title { get; set; } 
    public ICollection<Ingredient> Ingredient { get; set; }
    public string Hash { get; set; }

}