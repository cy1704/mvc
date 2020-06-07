using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class product
    {
        public int ID { set; get; }
        public string title { set; get; }
        public string Picure { set; get; }
        public string LinkUrl { set; get; }
        public int Pid { set; get; }
        public int sort { set; get; }
        public bool isHide { set; get; }
        public bool Isindex { set; get; }
        public DateTime CDate { set; get; }
        public string Content { set; get; }
    }
}
