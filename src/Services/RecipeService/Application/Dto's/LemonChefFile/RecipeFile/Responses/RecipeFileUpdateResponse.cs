﻿namespace Application.Dto_s.LemonChefFile.RecipeFile.Responses;

public record RecipeFileUpdateResponse(
    Guid Id,
    Guid RecipeId,
    Guid UserId,
    string FileName,
    string FileFormat,
    long FileSizeInBytes,
    long? Duration);