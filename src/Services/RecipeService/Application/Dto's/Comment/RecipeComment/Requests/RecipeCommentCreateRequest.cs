namespace Application.Dto_s.Comment.RecipeComment.Requests;

public class RecipeCommentCreateRequest : BaseCommentDto
{
    private Guid RecipeId { get; set; }
}