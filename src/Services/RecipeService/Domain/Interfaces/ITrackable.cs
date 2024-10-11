namespace Domain.Interfaces;

public interface ITrackable
{
    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string CreatedBy { get; set; }

    public string ModifiedBy { get; set; }

    public bool IsActive { get; set; }
}