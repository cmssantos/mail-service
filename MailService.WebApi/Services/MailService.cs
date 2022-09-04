using MailKit.Net.Smtp;
using MailKit.Security;
using MailService.WebApi.Enums;
using MailService.WebApi.Models;
using MimeKit;

namespace MailService.WebApi.Services;

public class MailService : IMailService
{
    public async Task SendEmailAsync(MailRequest request)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(request.Message.From.Name, request.Message.From.Email));
        message.Subject = request.Message.Subject;

        foreach (var emailTo in request.Message.To)
        {
            message.To.Add(new MailboxAddress(emailTo.Name, emailTo.Email));
        }

        var builder = new BodyBuilder();

        builder.HtmlBody = request.Message.Body;
        message.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        
        var secureSocketOptions = SecureSocketOptions.None;
        switch(request.Server.Cryptography) {
            case ECryptography.SSLTLS:
                secureSocketOptions = SecureSocketOptions.SslOnConnect;
                break;
            case ECryptography.STARTTLS:
                secureSocketOptions = SecureSocketOptions.StartTls;
                break;
        }
        
        smtp.Connect(request.Server.Host, request.Server.Port, secureSocketOptions);
        smtp.Authenticate(request.Server.UserName, request.Server.Password);

        await smtp.SendAsync(message);

        smtp.Disconnect(true);
    }
}