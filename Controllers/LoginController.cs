using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Text;
using FloralAppFE.Ecommerce.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FloralAppFE.Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HideLayout = true;
            TempData["token"] = null;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var apiUrl = "https://floralappapi.azurewebsites.net/api";
            var httpClient = new HttpClient();

            var requestBody = new { model.Email, model.Password };
            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{apiUrl}/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<Response<string>>(responseContent)!.Data;
                TempData["token"] = token;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View(model);
            }
        }
    }
}
