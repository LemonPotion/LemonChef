﻿namespace Application.Dto_s.LemonChefFile.CommentFile.Requests;

public record CommentFileUpdateRequest(
    Guid Id,
    Guid CommentId,
    Guid UserId);