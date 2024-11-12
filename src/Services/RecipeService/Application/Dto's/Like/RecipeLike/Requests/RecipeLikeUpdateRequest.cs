namespace Application.Dto_s.Like.RecipeLike.Requests;

public record RecipeLikeUpdateRequest(Guid Id, Guid RecipeId, Guid UserId);