namespace Application.Dto_s.LemonChefFile.IngredientFile.Requests;

public record IngredientFileUpdateRequest(
    Guid Id,
    Guid IngredientId,
    Guid UserId);