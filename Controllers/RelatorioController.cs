

using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Grafico()
        {
            return View();
        }
    }
}
