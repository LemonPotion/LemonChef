namespace Application.Dto_s.LemonChefFile.CommentFile.Responses;

public record CommentFileUpdateResponse(
    Guid Id,
    Guid CommentId,
    Guid UserId);