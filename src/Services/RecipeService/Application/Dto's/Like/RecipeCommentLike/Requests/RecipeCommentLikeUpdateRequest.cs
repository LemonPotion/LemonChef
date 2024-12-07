namespace Application.Dto_s.Like.RecipeCommentLike.Requests;

public record RecipeCommentLikeUpdateRequest(
    Guid Id, 
    Guid CommentId, 
    Guid UserId);