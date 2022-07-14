using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogV1._0.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        public IActionResult Bloglar(int? page)
        {
            var list = bm.GetAll().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Detaylar(int id)
        {
            //var list = bm.GetIdBlog(id);
            //return View(list);
            // Katmanlı mimaride include işlemi yapamadığımdan solidi eziyorum.
            var list = c.Blogs.Include(x => x.category).Include(x => x.writer).Where(x=>x.BlogID==id).ToList();
            return View(list);
        }
        // Kategori Sayfaları
        public IActionResult Yazılım(int? page)
        {
            var list = bm.GetYazılım().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Diziler(int? page)
        {
            var list = bm.GetDiziler().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Filmler(int? page)
        {
            var list = bm.GetFilmler().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Oyunlar(int? page)
        {
            var list = bm.GetOyunlar().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Teknoloji(int? page)
        {
            var list = bm.GetTeknoloji().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Müzik(int? page)
        {
            var list = bm.GetMuzik().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Edebiyat(int? page)
        {
            var list = bm.GetEdebiyat().ToPagedList(page ?? 1, 15);
            return View(list);
        }
        public IActionResult Sağlık(int? page)
        {
            var list = bm.GetSaglik().ToPagedList(page ?? 1, 15);
            return View(list);
        }

        // Kategori Sayfaları
    }
}
