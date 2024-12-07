using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.IngredientFile.Requests;

public record IngredientFileCreateRequest(
    Guid IngredientId,
    Guid UserId,
    FileDataDto FileData);