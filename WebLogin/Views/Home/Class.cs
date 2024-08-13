using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebLogin.Views.Home
{
    public class Class
    {
        internal class Class1
        {
            private static void Main()
            {
                Execute().Wait();
            }

            static async Task Execute()
            {
                var apiKey = Environment.GetEnvironmentVariable("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");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("d_bocanegra@seg.guanajuato.gob.mx", "Daniela Citlalli Bocanegra Barbosa");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("ma_martinez@seg.guanajuato.gob.mx", "Manuel Alejandro Martinez Márquez");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
    }
}
