using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogV1._0.Controllers
{
    [AllowAnonymous]
    public class ProjeController : Controller
    {
        ProjeManager pm = new ProjeManager(new EFProjeRepository());
        Context c = new Context();
        public IActionResult Projeler(int? page)
        {
            var list = pm.GetAll().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Detaylar(int id)
        {
            var list = c.Projes.Include(x => x.writer).Where(x => x.ProjeID == id).ToList();
            return View(list);
        }
    }
}
