using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.Dtos.TestimonialDtos;

namespace SignalR.UI.Controllers;

public class TestimonialController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public TestimonialController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:44306/api/testimonials");
        if (response.IsSuccessStatusCode)
        {
            var testimonials = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(testimonials);
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
    public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
    {
        createTestimonialDto.Status = true;
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(createTestimonialDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44306/api/testimonials", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:44306/api/testimonials/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44306/api/testimonials/getById/{id}");
        if (response.IsSuccessStatusCode)
        {
            var testimonial = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(testimonial);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(updateTestimonialDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:44306/api/testimonials", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
