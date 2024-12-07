using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.RecipeFile.Responses;

public record RecipeFileGetResponse(
    Guid Id,
    Guid RecipeId,
    Guid UserId,
    FileDataDto? FileData)
{
    public RecipeFileGetResponse() : this(default, default, default, default)
    {
    }
}