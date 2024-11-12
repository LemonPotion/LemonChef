namespace Application.Dto_s.LemonChefFile.CommentFile.Requests;

public record CommentFileCreateRequest(
    Guid CommentId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);