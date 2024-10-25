using Domain.Entities.Base;

namespace Domain.Entities;

public class CommentLike : Like
{
    public Comment Comment { get; set; }
    
    public Guid CommentId { get; set; }
}