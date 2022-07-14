using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFProjeRepository : GenericRepository<Proje>, IProjeDal
    {
        Context c = new Context();

        public List<Proje> GetCategory()
        {
            return c.Projes.Include(x => x.writer).ToList();
        }
    }
}
