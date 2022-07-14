using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.Controllers
{
    public class HataController : Controller
    {
        public IActionResult Hata404()
        {
            return View();
        }
    }
}
