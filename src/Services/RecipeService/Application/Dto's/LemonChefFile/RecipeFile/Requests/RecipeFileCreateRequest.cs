using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.RecipeFile.Requests;

public record RecipeFileCreateRequest(
    Guid RecipeId,
    Guid UserId,
    FileDataDto FileData);