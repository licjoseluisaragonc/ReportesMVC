/* REPORTES BD EXAMEN JARAGON
=========================================================================================
* Descripción: Lógica de negocio de accesos y login
* Historial de cambios:
* ---------------------------------------------------------------------------------------
*    Revisión   | Fecha      | Desarrollador                    | Resumen del cambio
* ---------------------------------------------------------------------------------------
*      1       | 06/02/2026 | Lic. José Luis Aragón Cervantes   | Creación
* ---------------------------------------------------------------------------------------
*/

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReportesMVC.Data;
using ReportesMVC.Models;

namespace ReportesMVC.Controllers
{
    public class AccesosController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<AccesosController> _logger;

        public AccesosController(AppDbContext db, IWebHostEnvironment env, ILogger<AccesosController> logger)
        {
            _db = db;
            _env = env;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(EntLoginDTO model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = (model.userAccess ?? "").Trim();
            var password = (model.passwordAccess ?? "").Trim();

            try
            {
                var u = await _db.Accesos.AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        (x.userAccess ?? "").Trim() == usuario &&
                        (x.passwordAccess ?? "").Trim() == password
                    );

                if (u == null)
                {
                    ViewBag.Error = "Credenciales inválidas.";
                    return View(model);
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, (u.userAccess ?? "").Trim()),
                        new Claim("Rol", (u.rollAccess ?? "").Trim()),
                        new Claim("Nombre", (u.nameUser ?? "").Trim()),
                        new Claim(ClaimTypes.Email, (u.emailUser ?? "").Trim()),
                        new Claim("AccesoId", u.id.ToString())
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Persona");
            }
            catch (Exception ex)
            {
                // aquí ya tienes tu try/catch para ver error de EF/SQL
                ViewBag.Error = _env.IsDevelopment() ? ex.Message : "Ocurrió un error inesperado.";
                _logger.LogError(ex, "Error en Login");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
