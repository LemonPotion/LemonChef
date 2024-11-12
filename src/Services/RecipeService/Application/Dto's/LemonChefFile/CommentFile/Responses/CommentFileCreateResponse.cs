﻿namespace Application.Dto_s.LemonChefFile.CommentFile.Responses;

public record CommentFileCreateResponse(
    Guid Id,
    Guid CommentId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);