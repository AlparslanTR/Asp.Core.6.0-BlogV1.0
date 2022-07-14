using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal? blogDal;

        public BlogManager(IBlogDal? blogDal)
        {
            this.blogDal = blogDal;
        }

        public List<Blog> GetAll()
        {
            return blogDal.GetCategory().ToList();
        }
        public List<Blog> GetAll4()
        {
            return blogDal.GetAll().TakeLast(4).ToList();
        }
        public List<Blog> GetAll7()
        {
            return blogDal.GetCategory().TakeLast(7).ToList();
        }
        public List<Blog> GetCategory()
        {
            return blogDal.GetCategory().TakeLast(4).ToList();
        }
        public Blog GetID(int id)
        {
            return blogDal.GetID(id);
        }
        public List<Blog> Get3LatesPost()
        {
            return blogDal.GetCategory().TakeLast(3).ToList();
        }
        public List<Blog> GetIdBlog(int id)
        {
            return blogDal.GetAll(x => x.BlogID == id);
        }
        public List<Blog> GetWriter()
        {
            return blogDal.GetAll(x => x.CategoryID == 1 && x.WriterID==1).TakeLast(3).ToList();
        }
        public List<Blog> GetWriter2()
        {
            return blogDal.GetCategoryWriter(x => x.CategoryID == 2 && x.WriterID == 1).TakeLast(3).ToList();
        }
        public List<Blog> GetWriter3()
        {
            return blogDal.GetCategoryWriter(x => x.CategoryID == 4 && x.WriterID == 1).TakeLast(3).ToList();
        }
        // Buradaki Metotlar Kategorileri tek sayfada listemek içindir
        public List<Blog> GetYazılım()
        {
            return blogDal.GetAll(x => x.CategoryID == 1).ToList();
        }
        public List<Blog> GetDiziler()
        {
            return blogDal.GetAll(x => x.CategoryID == 2).ToList();
        }
        public List<Blog> GetFilmler()
        {
            return blogDal.GetAll(x => x.CategoryID == 3).ToList();
        }
        public List<Blog> GetOyunlar()
        {
            return blogDal.GetAll(x => x.CategoryID == 4).ToList();
        }
        public List<Blog> GetTeknoloji()
        {
            return blogDal.GetAll(x => x.CategoryID == 5).ToList();
        }
        public List<Blog> GetMuzik()
        {
            return blogDal.GetAll(x => x.CategoryID == 6).ToList();
        }
        public List<Blog> GetEdebiyat()
        {
            return blogDal.GetAll(x => x.CategoryID == 7).ToList();
        }
        public List<Blog> GetSaglik()
        {
            return blogDal.GetAll(x => x.CategoryID == 8).ToList();
        }
        //Buradaki Metotlar Kategorileri tek sayfada listemek içindir
        
        // CRUD İşlemleri Burada
        public void TAdd(Blog t)
        {
            blogDal.Add(t);
        }

        public void TDelete(Blog t)
        {
            blogDal.Remove(t);
        }

        public void TUptade(Blog t)
        {
            blogDal.update(t);
        }
    }
}
