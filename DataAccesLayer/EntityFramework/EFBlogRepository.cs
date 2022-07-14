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
    public class EFBlogRepository:GenericRepository<Blog>,IBlogDal
    {
        Context c = new Context();
        public List<Blog> GetCategory()
        {
            return c.Blogs.Include(x=>x.category).Include(x=>x.writer).ToList();
        }

        public List<Blog> GetCategoryWriter()
        {
            return c.Blogs.Include(x => x.writer).ToList();
        }

        public List<Blog> GetIdBlog(int id)
        {
            return c.Blogs.Include(x => x.category).Where(x => x.WriterID == id).ToList();    
        }
    }
}
