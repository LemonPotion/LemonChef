namespace Application.Dto_s.Comment.RecipeComment.Requests;

public record RecipeCommentUpdateRequest(Guid Id, Guid RecipeId, string Text, Guid UserId);