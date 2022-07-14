using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.ViewComponents.Yazılım_3_Listele
{
    public class Yazılım3Listele:ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var list = bm.GetWriter();
            return View(list);
        }
    }
}
