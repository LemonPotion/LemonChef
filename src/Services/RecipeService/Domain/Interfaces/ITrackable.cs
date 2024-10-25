namespace Domain.Interfaces;

public interface ITrackable
{
    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }
}