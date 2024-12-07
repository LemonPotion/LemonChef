namespace Application.Dto_s.LemonChefFile.IngredientFile.Response;

public record IngredientFileUpdateResponse(
    Guid Id,
    Guid IngredientId,
    Guid UserId);