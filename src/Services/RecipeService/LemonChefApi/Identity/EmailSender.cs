using System.Net;
using System.Net.Mail;
using LemonChefApi.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace LemonChefApi.Identity;

public class EmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        
        _smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password),
            EnableSsl = true
        };
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage(_emailSettings.From, email, subject, htmlMessage);
        mailMessage.IsBodyHtml = true;
        await _smtpClient.SendMailAsync(mailMessage);
    }
}