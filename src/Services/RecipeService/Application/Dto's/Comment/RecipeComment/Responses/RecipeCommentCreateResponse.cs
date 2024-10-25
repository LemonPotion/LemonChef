namespace Application.Dto_s.Comment.RecipeComment.Responses;

public class RecipeCommentCreateResponse : BaseCommentDto
{
    public Guid Id { get; set; }
    
    public Guid RecipeId { get; set; }
}