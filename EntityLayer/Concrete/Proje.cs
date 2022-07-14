using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Proje
    {
        [Key]
        public int ProjeID { get; set; }
        public string? ProjeTitle { get; set; }
        public string? ProjeShort { get; set; }
        public string? ProjeContent { get; set; }
        public string? ProjeLittlePicture { get; set; }
        public string? ProjePicture { get; set; }
        public DateTime ProjeDate { get; set; }
        //
        public int WriterID { get; set; }
        public Writer? writer { get; set; }
    }
}
