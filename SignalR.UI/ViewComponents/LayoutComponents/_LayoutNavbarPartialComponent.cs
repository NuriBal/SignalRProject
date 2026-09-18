using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.LayoutComponents;

public class _LayoutNavbarPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
