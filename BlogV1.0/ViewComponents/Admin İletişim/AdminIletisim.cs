using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogV1._0.ViewComponents.Admin_İletişim
{
    public class AdminIletisim:ViewComponent
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        public IViewComponentResult Invoke()
        {
            var getir = cm.GetAll();
            return View(getir);
        }
    }
}
