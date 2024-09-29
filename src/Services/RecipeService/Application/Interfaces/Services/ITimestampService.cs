using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Interfaces.Services;

public interface ITimestampService
{
    public void UpdateTimeStamps(ChangeTracker changeTracker);
}