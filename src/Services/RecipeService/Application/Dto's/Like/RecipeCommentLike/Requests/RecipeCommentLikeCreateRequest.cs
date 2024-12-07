namespace Application.Dto_s.Like.RecipeCommentLike.Requests;

public record RecipeCommentLikeCreateRequest(
    Guid CommentId, 
    Guid UserId);