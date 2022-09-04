using MailService.WebApi.Enums;

namespace MailService.WebApi.Models;

public class MailServer {
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public ECryptography Cryptography { get; set; }
}