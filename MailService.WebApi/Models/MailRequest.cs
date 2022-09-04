namespace MailService.WebApi.Models;

public class MailRequest {
    public MailServer Server { get; set; }
    public MessageRequest Message { get; set; }
}