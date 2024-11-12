namespace Application.Dto_s.Comment.RecipeComment.Responses;

public record RecipeCommentGetResponse(Guid Id, Guid RecipeId, string Text, Guid UserId);