using Application.Interfaces.Services;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Services;

public class TimestampService : ITimestampService
{
    public void UpdateTimeStamps(ChangeTracker changeTracker)
    {
        var utcNow = DateTime.UtcNow;
        foreach (var entry in changeTracker.Entries<ITrackable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = utcNow;
                    entry.Entity.ModifiedOn = utcNow;
                    break;
                case EntityState.Modified:
                    entry.Property(x => x.CreatedOn).IsModified = false;
                    entry.Entity.ModifiedOn = utcNow;
                    break;
            }
        }
    }
}