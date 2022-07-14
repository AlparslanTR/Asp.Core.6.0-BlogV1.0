using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        public IActionResult Anasayfa()
        {
            return View();
        }
        public IActionResult Hakkımızda()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Iletişim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Iletişim(Contact p)
        {
            p.ContactDate=System.DateTime.Now;
            cm.TAdd(p);
            return RedirectToAction("Iletişim", "Home");
        }
        public IActionResult MarchOfEmpires()
        {
            return View();
        }
        public IActionResult Valorant()
        {
            return View();
        }
        public IActionResult Twitter()
        {
            return View();
        }
        public IActionResult Gibi()
        {
            return View();
        }
    }
}
