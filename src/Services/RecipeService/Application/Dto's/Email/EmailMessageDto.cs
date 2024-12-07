namespace Application.Dto_s.Email;

public record EmailMessageDto(
    string ToAddress,
    string Subject,
    string? Body,
    string? AttachmentPath = default);