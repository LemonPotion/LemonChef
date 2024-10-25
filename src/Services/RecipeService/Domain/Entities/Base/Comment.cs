using Domain.Interfaces;
using Domain.Validations.Validators;
using FluentValidation;

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

    public Comment()
    {
        
    }

    public Comment(Guid userId, string text)
    {
        UserId = userId;
        Text = text;
        
        var validator = new CommentValidator(nameof(Comment));
        validator.ValidateAndThrow(this);
    }
}