namespace Domain.Entities.Base;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; }
}