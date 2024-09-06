using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

public class RecipiesDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public RecipiesDbContext(DbContextOptions<RecipiesDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipiesDbContext).Assembly);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        var now = DateTime.UtcNow;
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreatedOn= now;
                        entity.ModifiedOn = now;
                        break;

                    case EntityState.Modified:
                        Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                        entity.ModifiedOn= now;
                        break;
                }
            }
        }
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        var utcNow = DateTime.UtcNow;
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreatedOn= utcNow;
                        entity.ModifiedOn = utcNow;
                        break;

                    case EntityState.Modified:
                        Entry(entity).Property(x => x.CreatedOn).IsModified = false;
                        entity.ModifiedOn= utcNow;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                }
            }
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}