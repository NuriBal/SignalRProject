using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index() => View();
}
