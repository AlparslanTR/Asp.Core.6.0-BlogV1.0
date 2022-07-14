using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.ViewComponents.Dizi_Listele_3
{
    public class DiziListele3: ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var list = bm.GetWriter2();
            return View(list);
        }
    }
}
