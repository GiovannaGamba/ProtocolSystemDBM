using Microsoft.AspNetCore.Mvc;

namespace ProtocolSystemDBM.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Gest�o de Clientes";
        return View();
    }
}
