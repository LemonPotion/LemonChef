using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.CommentFile.Responses;

public record CommentFileGetResponse(
    Guid Id,
    Guid CommentId,
    Guid UserId,
    FileDataDto? FileData)
{
    public CommentFileGetResponse() : this(default, default, default, default)
    {
    }
}