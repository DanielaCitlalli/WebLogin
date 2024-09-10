using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Diagnostics;
using WebLogin.Models;

namespace WebLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            return View();
        }

        // Acción para procesar el formulario y redirigir a Mensajeria
        [HttpPost]
        public ActionResult RedirigirAMensajeria()
        {
            return RedirectToAction("Mensajeria");
        }

        // Acción para la vista Mensajeria
        public ActionResult Mensajeria()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly string sendGridApiKey = "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";

        // Acción que recibe los datos del formulario y envía el correo
        [HttpPost]
        public async Task<IActionResult> SendEmail(string emailTo, string subject)
        {
            var result = await SendEmailAsync(emailTo, subject);

            if (result.Success)
            {
                ViewBag.Message = "Correo enviado correctamente";
            }
            else
            {
                ViewBag.Message = $"Error al enviar el correo: {result.ErrorMessage}";
            }

            return View("Mensajeria");
        }

        // Método para enviar el correo usando SendGrid
        private async Task<(bool Success, string ErrorMessage)> SendEmailAsync(string emailTo, string subject)
        {
            try
            {
                var client = new SendGridClient(sendGridApiKey);
                var from = new EmailAddress("d_bocanegra@seg.guanajuato.gob.mx", "Daniela");
                var to = new EmailAddress(emailTo);
                var plainTextContent = "Este es el contenido del correo en texto plano.";
                var htmlContent = "<strong>Este es el contenido del correo en HTML.</strong>";

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                // Verificar si la respuesta es exitosa
                if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return (true, null);  // Éxito
                }
                else
                {
                    // Leer detalles del error
                    var body = await response.Body.ReadAsStringAsync();
                    return (false, $"Error de SendGrid: {body}");
                }
            }
            catch (Exception ex)
            {
                // Capturar la excepción y devolver el mensaje de error
                return (false, $"Excepción: {ex.Message}");
            }
        }
    }
}
