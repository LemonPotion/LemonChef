namespace Application.Dto_s.Like.RecipeCommentLike.Responses;

public record RecipeCommentLikeCreateResponse(
    Guid Id, 
    Guid CommentId, 
    Guid UserId);