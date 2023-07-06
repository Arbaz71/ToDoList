using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
