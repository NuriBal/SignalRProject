using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.Dtos.DiscountDtos;

namespace SignalR.UI.Controllers;

public class DiscountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public DiscountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:44306/api/discounts");
        if (response.IsSuccessStatusCode)
        {
            var discounts = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(discounts);
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
    public async Task<IActionResult> Create(CreateDiscountDto createDiscountDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(createDiscountDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44306/api/discounts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:44306/api/discounts/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44306/api/discounts/getById/{id}");
        if (response.IsSuccessStatusCode)
        {
            var discount = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateDiscountDto>(discount);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateDiscountDto updateDiscountDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(updateDiscountDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:44306/api/discounts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
