﻿
using Microsoft.AspNetCore.Mvc;

namespace FloralAppFE.Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
