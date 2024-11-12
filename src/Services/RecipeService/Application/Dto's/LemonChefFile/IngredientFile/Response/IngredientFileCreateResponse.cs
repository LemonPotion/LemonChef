namespace Application.Dto_s.LemonChefFile.IngredientFile.Response;

public record IngredientFileCreateResponse(
    Guid Id,
    Guid IngredientId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);