using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.Dtos.FeatureDtos;

namespace SignalR.UI.Controllers;

public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public FeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:44306/api/features");
        if (response.IsSuccessStatusCode)
        {
            var features = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(features);
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
    public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(createFeatureDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44306/api/features", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:44306/api/features/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44306/api/features/getById/{id}");
        if (response.IsSuccessStatusCode)
        {
            var feature = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(feature);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(updateFeatureDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:44306/api/features", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
