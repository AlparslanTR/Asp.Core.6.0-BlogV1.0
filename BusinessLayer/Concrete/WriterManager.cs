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
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public List<Writer> GetAll()
        {
            return writerDal.GetAll();
        }

        public Writer GetID(int id)
        {
            return writerDal.GetID(id);
        }

        public void TAdd(Writer t)
        {
            writerDal.Add(t);
        }

        public void TDelete(Writer t)
        {
            writerDal.Remove(t);
        }

        public void TUptade(Writer t)
        {
            writerDal.update(t);
        }
    }
}
