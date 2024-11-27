using Microsoft.AspNetCore.Mvc;

namespace OutletStore_UI.Controllers;
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
