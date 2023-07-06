using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }

            // Perform authentication logic
            if (IsValidUser(loginUser.Email, loginUser.Password))
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, loginUser.Email),
            };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home"); // Replace with your desired action and controller
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(loginUser);
        }

        private bool IsValidUser(string email, string password)
        {
            // Implement your logic to validate the user credentials
            // You can check against your data store or any other authentication mechanism
            // For demonstration purposes, let's assume a valid user exists with email: "test@example.com" and password: "password"
            return (email == "test@example.com" && password == "password");
        }
    }
}
