using MailService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using MailService.WebApi.Services;

namespace MailService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailController : ControllerBase
{
    private readonly ILogger<MailController> _logger;
    private readonly IMailService mailService;

    public MailController(ILogger<MailController> logger, IMailService mailService)
    {
        this._logger = logger;
        this.mailService = mailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMail(MailRequest request)
    {
        try
        {
            await mailService.SendEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }

    }
}