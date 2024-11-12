namespace Application.Dto_s.Like.RecipeLike.Responses;

public record RecipeLikeCreateResponse(Guid Id, Guid RecipeId, Guid UserId);