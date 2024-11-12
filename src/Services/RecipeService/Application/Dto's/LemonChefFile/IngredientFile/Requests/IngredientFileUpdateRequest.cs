namespace Application.Dto_s.LemonChefFile.IngredientFile.Requests;

public record IngredientFileUpdateRequest(
    Guid Id,
    Guid IngredientId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);