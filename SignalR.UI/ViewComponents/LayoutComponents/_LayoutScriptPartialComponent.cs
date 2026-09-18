using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.LayoutComponents;

public class _LayoutScriptPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
