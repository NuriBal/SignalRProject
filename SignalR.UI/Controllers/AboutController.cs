using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.Dtos.AboutDtos;

namespace SignalR.UI.Controllers;

public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:44306/api/abouts");
        if (response.IsSuccessStatusCode)
        {
            var abouts = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(abouts);
            return View(values);
        }
        return View();        
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(createAboutDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44306/api/abouts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:44306/api/abouts/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44306/api/abouts/getById/{id}");
        if (response.IsSuccessStatusCode)
        {
            var about = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAboutDto>(about);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(updateAboutDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:44306/api/abouts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
