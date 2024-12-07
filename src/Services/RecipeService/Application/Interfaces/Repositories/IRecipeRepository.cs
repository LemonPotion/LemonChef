﻿using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    public Task<List<Recipe>> GetAllByUserIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<List<Ingredient>> GetRecipeIngredientsByRecipeId(Guid recipeId, CancellationToken cancellationToken = default);
}