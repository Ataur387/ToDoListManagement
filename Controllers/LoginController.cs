using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Data.Services;
using ToDoListManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ToDoListManagement.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InvalidUser()
        {
            return View();
        }
        public IActionResult validUser()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "ToDoList");
        }
        [HttpPost]
        public async Task<IActionResult> LoginVerificationAsync([Bind("Id", "Name", "UserName", "Password", "Role")] UserModel User)
        {
            if (string.IsNullOrEmpty(User.UserName) || string.IsNullOrEmpty(User.Password))
            {
                return RedirectToAction("Index");
            }
            var result = await _service.FindRoleAsync(User);
            if (result != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, result.UserName),
                        new Claim(ClaimTypes.Role, result.Role),
                    };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToAction("Index", "ToDoList");

            }
            else
            {
                return RedirectToAction("InvalidUser");
            }
        }
    }
}
