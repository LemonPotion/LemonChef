namespace Application.Dto_s.Comment.RecipeComment.Requests;

public class RecipeCommentUpdateRequest : BaseCommentDto
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }
}