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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal? categoryDal;
        public CategoryManager(ICategoryDal? categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public Category GetID(int id)
        {
            return categoryDal.GetID(id);
        }
        // CRUD İşlemleri Burada
        public void TAdd(Category t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category t)
        {
            
        }

        public void TUptade(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
