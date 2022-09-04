namespace MailService.WebApi.Models;

public class MessageRequest {
    public MailAddress From { get; set; }
    public IList<MailAddress> To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}