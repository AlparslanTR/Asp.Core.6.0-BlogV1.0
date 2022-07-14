using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogShort { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogLittlePicture { get; set; }
        public string? BlogPicture { get; set; }
        public DateTime BlogDate { get; set; }
        //
        public int CategoryID { get; set; }
        public Category? category { get; set; }
        //
        public int WriterID { get; set; }
        public Writer? writer { get; set; }
        //

    }
}
