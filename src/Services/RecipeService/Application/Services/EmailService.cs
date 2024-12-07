using Application.Dto_s.Email;
using Application.Interfaces.Services;
using FluentEmail.Core;

namespace Application.Services;

public class EmailService : IEmailService
{
    private readonly IFluentEmailFactory _fluentEmailFactory;

    public EmailService(IFluentEmailFactory fluentEmailFactory)
    {
        _fluentEmailFactory = fluentEmailFactory;
    }

    public async Task SendAsync(EmailMessageDto emailMessage, CancellationToken cancellationToken = default)
    {
        await _fluentEmailFactory.Create()
            .To(emailMessage.ToAddress)
            .Subject(emailMessage.Subject)
            .Body(emailMessage.Body, true)
            .SendAsync(cancellationToken);
    }
}