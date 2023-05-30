using FloralAppFE.Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FloralAppFE.Ecommerce.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var apiUrl = "https://floralappapi.azurewebsites.net/api";
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{apiUrl}/customers", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<object>>(responseContent);

            if (result!.Success)
            {

                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Invalid creation attempt");
                return View(model);
            }
        }
    }
}
