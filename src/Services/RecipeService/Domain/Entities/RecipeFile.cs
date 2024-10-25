using Domain.Entities.Base;
using Domain.Interfaces;

namespace Domain.Entities;

public class RecipeFile : LemonChefFile
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}