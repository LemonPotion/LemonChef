namespace Application.Dto_s.LemonChefFile.RecipeFile.Requests;

public record RecipeFileUpdateRequest(
    Guid Id,
    Guid RecipeId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);