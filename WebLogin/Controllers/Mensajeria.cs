using Microsoft.AspNetCore.Mvc;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Threading.Tasks;

    namespace YourNamespace.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
    [HttpPost("send-email")]
    public async Task<IActionResult>
    SendEmail([FromBody] EmailRequest request)
    {
    var apiKey = Environment.GetEnvironmentVariable("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");
    var client = new SendGridClient(apiKey);
    var from = new EmailAddress("test@example.com", "Example User");
    var subject = request.Subject;
    var to = new EmailAddress(request.ToEmail);
    var plainTextContent = request.Message;
    var htmlContent = $"<strong>{request.Message}</strong>";
    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
    var response = await client.SendEmailAsync(msg);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
    return Ok();
    }
    else
    {
    return StatusCode((int)response.StatusCode, response.Body.ReadAsStringAsync().Result);
    }
    }
    }

    public class EmailRequest
    {
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    }

    }
