using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class lmgl
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public int Pid { set; get; }
        public int Sort { set; get; }
        public int Ctype { set; get; }
        public bool IsHide { set; get; }
        public string Content { set; get; }
        public string LinkUrl { set; get; }
        public string Picture { set; get; }
        public DateTime Cdate { set; get; }
    }
}
