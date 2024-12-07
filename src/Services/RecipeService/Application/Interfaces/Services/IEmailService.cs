using Application.Dto_s.Email;

namespace Application.Interfaces.Services;

public interface IEmailService
{
    Task SendAsync(EmailMessageDto emailMessage, CancellationToken cancellationToken = default);
}