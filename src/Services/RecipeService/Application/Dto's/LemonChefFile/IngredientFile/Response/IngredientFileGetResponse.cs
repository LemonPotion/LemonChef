using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.IngredientFile.Response;

public record IngredientFileGetResponse(
    Guid Id,
    Guid IngredientId,
    Guid UserId,
    FileDataDto? FileData)
{
    public IngredientFileGetResponse() : this(default, default, default, default)
    {
    }
}