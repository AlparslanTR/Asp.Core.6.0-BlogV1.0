using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void update(T entity);
        List<T> GetAll();
        T GetID(int id);
        List<T> GetAll(Expression<Func<T,bool>>filtre);
        List<T> GetCategoryWriter(Expression<Func<T, bool>> filtre);
    }
}
