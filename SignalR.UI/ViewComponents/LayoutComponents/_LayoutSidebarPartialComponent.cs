using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.LayoutComponents;

public class _LayoutSidebarPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
