namespace Application.Dto_s.Like.RecipeLike.Requests;

//TODO: добавить все типы дто (например: получить все сущности (ответ))
public record RecipeLikeCreateRequest(
    Guid RecipeId, 
    Guid UserId);