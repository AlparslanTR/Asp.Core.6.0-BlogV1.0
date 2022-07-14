using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.ViewComponents.Anasayfa_Son_Eklenen_4_Blog_Listeleme
{
    public class Son4Blog : ViewComponent
    {
        BlogManager bm= new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var getir = bm.GetCategory();
            return View(getir);
        }
    }
}
