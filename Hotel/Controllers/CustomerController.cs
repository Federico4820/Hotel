using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
