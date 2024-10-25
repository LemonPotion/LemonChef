namespace Application.Dto_s.Comment.RecipeComment.Responses;

public class RecipeCommentUpdateResponse : BaseCommentDto
{
    public Guid Id { get; set; }
    
    public Guid RecipeId { get; set; }
}