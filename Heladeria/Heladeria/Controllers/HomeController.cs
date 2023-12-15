using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Heladeria.Models;
using Heladeria.Utilities;

namespace Heladeria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountRepository _accountRepository;


        public HomeController(ILogger<HomeController> logger, AccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            RegisterUser usuario = new RegisterUser();
            return View(usuario);
        }

        public async Task<IActionResult> Login(UserLoginDTO obj)
        {
            if (ModelState.IsValid)
            {
                UserLoginResponseDTO objUser = await _accountRepository.LoginAsync(UrlResources.UrlUsers + "Login", obj);
                if (objUser.Token == null)
                {
                    //TempData["alert"] = "Los datos son incorrectos";
                    return View();
                }

                // Crear identidad y principal solo si el token es exitoso
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, objUser.User.UserName)
            // Puedes agregar más claims según sea necesario
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("JWToken", objUser.Token);
                TempData["alert"] = "Bienvenido/a " + objUser.User.UserName;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }



        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(UserRegisterDTO userRegisterDTO)
        {
            userRegisterDTO.Roles = new List<string>();
            userRegisterDTO.Roles.Add("Registrado");

            bool result = await _accountRepository.RegisterAsync(UrlResources.UrlUsers + "Registro", userRegisterDTO);
            if (result == false)
            {
                return View();
            }

            TempData["alert"] = "Registro correcto";
            return RedirectToAction("Login");
        }


        public async Task<IActionResult> Logout()
        {
            // Realizar cualquier lógica de cierre de sesión necesaria
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Limpiar cualquier información adicional de la sesión
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

    public class UserLoginDTO
    {
    }
}