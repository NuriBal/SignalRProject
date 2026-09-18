using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.LayoutComponents;

public class _LayoutFooterPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
