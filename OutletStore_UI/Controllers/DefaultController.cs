using Microsoft.AspNetCore.Mvc;

namespace OutletStore_UI.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
