using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class column
    {
        public int id { set; get; }
        public string title { set; get; }
        public int pid { set; get; }
        public int sort { set; get; }
        public int ctype { set; get; }
        public bool IsHide { set; get; }
        public string Content { set; get; }
        public string LinkUrl { set; get; }
        public string Picture { set; get; }
        public DateTime cdate { set; get; }
    }
}
