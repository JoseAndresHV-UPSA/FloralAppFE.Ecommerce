
using Microsoft.AspNetCore.Mvc;

namespace FloralAppFE.Ecommerce.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
