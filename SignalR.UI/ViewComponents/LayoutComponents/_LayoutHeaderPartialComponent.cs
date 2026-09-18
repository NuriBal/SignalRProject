using Microsoft.AspNetCore.Mvc;

namespace SignalR.UI.ViewComponents.LayoutComponents;

public class _LayoutHeaderPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
