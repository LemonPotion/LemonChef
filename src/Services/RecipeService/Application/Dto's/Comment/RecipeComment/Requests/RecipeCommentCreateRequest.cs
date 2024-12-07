namespace Application.Dto_s.Comment.RecipeComment.Requests;

public record RecipeCommentCreateRequest(
    Guid RecipeId,
    string Text,
    Guid UserId);