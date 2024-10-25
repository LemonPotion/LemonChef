using Domain.Entities.Base;

namespace Domain.Entities;

public class RecipeComment : Comment
{
    public Guid RecipeId { get; set; }

    public Recipe Recipe { get; set; }

    public ICollection<RecipeCommentLike> RecipeCommentLikes { get; set; }
    
    public long LikeCount { get; set; }
}