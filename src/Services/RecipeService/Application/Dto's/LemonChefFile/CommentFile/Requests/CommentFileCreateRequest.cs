using Application.Dto_s.LemonChefFile.FileData;

namespace Application.Dto_s.LemonChefFile.CommentFile.Requests;

public record CommentFileCreateRequest(
    Guid CommentId,
    Guid UserId,
    FileDataDto FileData);