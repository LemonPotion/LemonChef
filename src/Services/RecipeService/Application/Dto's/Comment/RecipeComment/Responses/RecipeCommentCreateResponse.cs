namespace Application.Dto_s.Comment.RecipeComment.Responses;

public record RecipeCommentCreateResponse(
    Guid Id, 
    Guid RecipeId, 
    string Text, 
    Guid UserId);