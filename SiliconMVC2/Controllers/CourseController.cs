using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconMVC2.ViewModels;

namespace SiliconMVC2.Controllers;

[Authorize]
public class CourseController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;


    [Route("/courses")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new CourseIndexViewModel();

        var response = await _httpClient.GetAsync("https://localhost:7282/api/Courses");
        if(response.IsSuccessStatusCode)
        {
            var courses = JsonConvert.DeserializeObject<IEnumerable<CoursesModel>>(await response.Content.ReadAsStringAsync());
            if(courses != null)
                viewModel.Courses = courses;

        }


        return View(viewModel);
    }
}
