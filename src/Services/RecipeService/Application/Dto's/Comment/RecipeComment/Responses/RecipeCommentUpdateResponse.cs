namespace Application.Dto_s.Comment.RecipeComment.Responses;

public record RecipeCommentUpdateResponse(Guid Id, Guid RecipeId, string Text, Guid UserId);