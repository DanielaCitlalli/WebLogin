

/*internal class Program1
{
    private static void Main(string[] args)
    {
    }

    private static void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}*/


//segundo intento 



/*using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
//using System.Web.Mvc;
using System.Net.Mail;
//using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class Mensajeria : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        // Acción para enviar el correo electrónico
        public async Task<ActionResult> SendEmail()
        {
            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return Content("Email sent successfully!");
        }
    }
}*/