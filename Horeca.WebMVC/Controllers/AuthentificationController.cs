using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.Models.CustomModels;
using Horeca.DataBaseLibrary.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horeca.WebMVC.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly IDaAuthentificationDataService _authentificationData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthentificationController(IDaAuthentificationDataService authentificationData, IHttpContextAccessor httpContextAccessor)
        {
            _authentificationData = authentificationData;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccesToAuthentificationModel selectData)
        {
            var user = await _authentificationData.SelectDataAcces(selectData);
            if (user == null)
            {
                ViewBag.Message = "Invalid Credential";
                return View("Login");
            }
            else
            {
                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.NameAcces)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AuthentificationModel newUser)
        {
            await _authentificationData.RegisterAccount(newUser);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ViewUsers()
        {
            List<AuthentificationModel> allUsers = await _authentificationData.ViewAccounts();
            return View(allUsers);
        }
        [HttpGet]
        public async Task<IActionResult> CreateEmployeeUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeUser(AuthentificationModel employeeUser)
        {
            await _authentificationData.InsertAccount(employeeUser);
            return RedirectToAction("ViewUsers");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            AuthentificationModel setInnactive = await _authentificationData.SelectUserById(id);
            return View(setInnactive);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(AuthentificationModel setInnactive)
        {
            await _authentificationData.DeleteUser(setInnactive);
            return RedirectToAction("ViewUsers");
        }

        [HttpGet]
        public async Task<IActionResult> Logout(AuthentificationModel model)
        {
            await _authentificationData.SelectAccount(model);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
