namespace Application.Dto_s.LemonChefFile.IngredientFile.Response;

public record IngredientFileCreateResponse(
    Guid Id,
    Guid IngredientId,
    Guid UserId,
    string GoogleDriveId);