using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        public void Add(T entity)
        {
            c.Add(entity);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filtre)
        {
            return c.Set<T>().Where(filtre).ToList();
        }

        public List<T> GetCategoryWriter(Expression<Func<T, bool>> filtre)
        {
            return c.Set<T>().Where(filtre).ToList();
        }

        public T GetID(int id)
        {
            return c.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            c.Remove(entity);
            c.SaveChanges();
        }

        public void update(T entity)
        {
            c.Update(entity);
            c.SaveChanges();
        }
    }
}
