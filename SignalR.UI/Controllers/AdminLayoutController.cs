using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers;

public class AdminLayoutController : Controller
{
    public IActionResult Index() => View();
}
