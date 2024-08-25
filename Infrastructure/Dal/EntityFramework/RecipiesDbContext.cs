using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

public class RecipiesDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    
    public RecipiesDbContext(DbContextOptions<RecipiesDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipiesDbContext).Assembly);
    }
}