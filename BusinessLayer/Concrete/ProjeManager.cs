using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProjeManager : IProjeService
    {
        IProjeDal? ProjeDal;

        public ProjeManager(IProjeDal? projeDal)
        {
            ProjeDal = projeDal;
        }

        public List<Proje> GetAll()
        {
            return ProjeDal.GetCategory().ToList();
        }
        public List<Proje> GetAll3()
        {
            return ProjeDal.GetCategory().TakeLast(3).ToList();
        }
        public Proje GetID(int id)
        {
            return ProjeDal.GetID(id);
        }

        public List<Proje> GetWriter()
        {
            throw new NotImplementedException();
        }
        // CRUD İşlemleri Burada
        public void TAdd(Proje t)
        {
            ProjeDal.Add(t);
        }

        public void TDelete(Proje t)
        {
            ProjeDal.Remove(t);
        }

        public void TUptade(Proje t)
        {
            ProjeDal.update(t);
        }
    }
}
