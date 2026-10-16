using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.Controllers;

public class SignalRDefaultController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

}

