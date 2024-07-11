using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Pierre.Models;
using System.Security.Claims;
using Restaurant_Pierre.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_Pierre.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }


        



        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            ValidarUsuarioService _da_usuario = new();

            var usuario = _da_usuario.ValidarUsuario(_usuario.IdEmpleadoNavigation.Email, _usuario.Usuario1, _usuario.Password);
            ViewBag.Horror = _da_usuario.Horror;
            if (usuario != null)
            {

                //2.- CONFIGURACION DE LA AUTENTICACION
                #region AUTENTICACTION
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.IdEmpleadoNavigation.Nombre),
                    new Claim("Correo", usuario.Usuario1),
                    new Claim(ClaimTypes.Role, usuario.IdRolNavigation.Rol1)
            };
                
                    
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                #endregion


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Registrar([Bind("IdUsuario,Usuario1,Password,IdRol,IdEmpleado")] Usuario usuario) {
            ValidarUsuarioService _da_usuario = new();
            string hola = null;

            if (ModelState.IsValid)
            {
                
                _da_usuario.CrearUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            _da_usuario.CrearUsuario(usuario, hola);
            ViewData["IdEmpleado"] = _da_usuario.Datos1;
            ViewData["IdRol"] = _da_usuario.Datos2;
            return View(usuario);
            
        }










        public async Task<IActionResult> Salir()
        {
            //3.- CONFIGURACION DE LA AUTENTICACION
            #region AUTENTICACTION
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return RedirectToAction("Index");

        }

    }
}
