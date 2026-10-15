using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.UI.Dtos.ContactDtos;

namespace SignalR.UI.Controllers;

public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:44306/api/contacts");
        if (response.IsSuccessStatusCode)
        {
            var contacts = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(contacts);
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
    public async Task<IActionResult> Create(CreateContactDto createContactDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(createContactDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44306/api/contacts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.DeleteAsync($"https://localhost:44306/api/contacts/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"https://localhost:44306/api/contacts/getById/{id}");
        if (response.IsSuccessStatusCode)
        {
            var contact = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateContactDto>(contact);
            return View(value);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonConvert.SerializeObject(updateContactDto), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PutAsync("https://localhost:44306/api/contacts", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
