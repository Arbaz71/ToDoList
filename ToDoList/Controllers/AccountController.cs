using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class AccountController : Controller
    {
        private readonly object _signManager;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
