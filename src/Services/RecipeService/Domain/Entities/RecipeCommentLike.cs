using Domain.Entities.Base;

namespace Domain.Entities;

public class RecipeCommentLike : CommentLike
{
    public Guid RecipeCommentId { get; set; }

    public RecipeComment RecipeComment { get; set; }
}