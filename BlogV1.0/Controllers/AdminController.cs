using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList;

namespace BlogV1._0.Controllers
{
    public class AdminController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());
        BlogManager bm = new BlogManager(new EFBlogRepository());
        ProjeManager pm = new ProjeManager(new EFProjeRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        ContactManager im=new ContactManager(new EFContactRepository());
        Context c = new Context();
        /////////// Kullanıcı Giriş/////////////
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task <IActionResult> Giris(Writer p)
        {
            var giris = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (giris != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Profil", "Admin");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Çıkış()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Giris", "Admin");
        }
        [HttpGet]
        public IActionResult Profil()
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            var profil=wm.GetID(writer);
            return View(profil);
        }
        [HttpPost]
        public IActionResult Profil(Writer p)
        {
            if (p == null)
            {
                return View();
            }
            else
            {
                wm.TUptade(p);
                RedirectToAction("Profil", "Admin");
            }
            return View();
        }
        /////////// Kullanıcı Giriş/////////////
        //------------------------------------//
        /////////// Admin Teması/////////////
        public PartialViewResult Sidebar()
        {
            return PartialView();
        }
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        /////////// Admin Teması/////////////
        //------------------------------------//
        public IActionResult İstatistikler(int? page)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            ViewBag.blog = c.Blogs.Count();
            ViewBag.projes = c.Projes.Count();          
            var list = bm.GetAll().ToPagedList(page ?? 1, 10);
            return View(list);
        }
        /////////// Blog İşlemleri/////////////
         //------------------------------------//
        public IActionResult BlogListesi(int? page)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            var list = bm.GetAll().ToPagedList(page ?? 1, 10);
            return View(list);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            List<SelectListItem> Kategoriler = (from x in cm.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString(),
                                                }).ToList();
            ViewBag.ktg = Kategoriler;
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Blog p)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            p.BlogDate = System.DateTime.Now;
            p.WriterID = writer;
            bm.TAdd(p);
            return RedirectToAction("BlogListesi", "Admin");
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            List<SelectListItem> Kategoriler = (from x in cm.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString(),
                                                }).ToList();
            ViewBag.ktg = Kategoriler;
            var getir = bm.GetID(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult Guncelle(Blog p)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            p.BlogDate=System.DateTime.Now;
            p.WriterID = writer;
            bm.TUptade(p);
           return RedirectToAction("BlogListesi", "Admin");
        }
        public IActionResult Sil(int id)
        {
            var getir = bm.GetID(id);
            bm.TDelete(getir);
            return RedirectToAction("BlogListesi", "Admin");
        }
        /////////// Blog İşlemleri/////////////
        //---------------------//
        /////////// Proje İşlemleri/////////////
        //---------------------//
        public IActionResult ProjeListesi(int? page)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            var list = pm.GetAll().ToPagedList(page ?? 1, 10);
            return View(list);
        }
        [HttpGet]
        public IActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkle(Proje p)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            p.ProjeDate = System.DateTime.Now;
            p.WriterID = writer;
            pm.TAdd(p);
            return RedirectToAction("ProjeListesi", "Admin");
        }
        [HttpGet]
        public IActionResult ProjeGuncelle(int id)
        {
            var getir = pm.GetID(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult ProjeGuncelle(Proje p)
        {
            var login = User.Identity.Name;
            var writer = c.Writers.Where(x => x.WriterMail == login).Select(x => x.WriterID).FirstOrDefault();
            p.ProjeDate = System.DateTime.Now;
            p.WriterID = writer;
            pm.TUptade(p);
            return RedirectToAction("ProjeListesi", "Admin");
        }
        public IActionResult ProjeSil(int id)
        {
            var getir = pm.GetID(id);
            pm.TDelete(getir);
            return RedirectToAction("ProjeListesi", "Admin");
        }
        /////////// Proje İşlemleri/////////////
        //---------------------//
        public IActionResult MesajOku(int id)
        {
            var getir=im.GetID(id);
            return View(getir);
        }
    }
}
