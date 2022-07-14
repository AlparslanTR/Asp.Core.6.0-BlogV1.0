using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogV1._0.ViewComponents.Kategori_Tab
{
    public class TabKategori:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var list = c.Categories.Include("blogs").ToList().OrderBy(x => x.CategoryName);
            return View(list);
        }
    }
}
