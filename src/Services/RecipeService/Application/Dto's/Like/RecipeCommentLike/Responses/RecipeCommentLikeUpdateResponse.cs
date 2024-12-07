namespace Application.Dto_s.Like.RecipeCommentLike.Responses;

public record RecipeCommentLikeUpdateResponse(
    Guid Id, 
    Guid CommentId, 
    Guid UserId);