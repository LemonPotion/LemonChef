using Domain.Interfaces;

namespace Domain.Entities.Base;

public class Comment : BaseEntity, ITrackable
{
    public Guid UserId { get; set; }

    public User User { get; set; }

    public string Text { get; set; }

    public ICollection<CommentFile>? Files { get; set; }
    
    public ICollection<CommentLike>? Likes { get; set; }
    
    public long LikeCount { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; set; }
}