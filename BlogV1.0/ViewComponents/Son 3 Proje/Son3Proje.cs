using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.ViewComponents.Son_3_Proje
{
    public class Son3Proje:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
