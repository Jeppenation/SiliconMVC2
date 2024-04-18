using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconMVC2.ViewModels;
using System.Net.Http;
using System.Text;

namespace SiliconMVC2.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    [Route("/")]
    public IActionResult Index()
    {
        var model = new HomeIndexViewModel();
        ViewData["Title"] = "Home Page";

        return View(model);
    }

    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if(ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7282/api/Subscribe", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You have successfully subscribed!";
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["StatusMessage"] = "You are already subscribed!";
            }
          
        }
        else
        {
            TempData["StatusMessage"] = "An error occurred while subscribing!";
        }

        return RedirectToAction("Index", "Home", "subscribe");
    }
}
