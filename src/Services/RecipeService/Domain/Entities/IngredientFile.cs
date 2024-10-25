using Domain.Entities.Base;
using Domain.Interfaces;

namespace Domain.Entities;

public class IngredientFile : LemonChefFile
{
    public Guid IngredientId { get; set; }

    public Ingredient Ingredient { get; set; }
}