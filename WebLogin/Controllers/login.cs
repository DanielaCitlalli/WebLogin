/*using Microsoft.AspNetCore.Mvc;

namespace TuProyecto.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                // Login exitoso
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Login fallido
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }
        }
    }
}*/
