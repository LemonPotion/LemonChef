namespace Application.Dto_s.Like.RecipeCommentLike.Responses;

public record RecipeCommentLikeGetResponse(
    Guid Id, 
    Guid CommentId, 
    Guid UserId);