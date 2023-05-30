using Microsoft.AspNetCore.Mvc;

namespace FloralAppFE.Ecommerce.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
