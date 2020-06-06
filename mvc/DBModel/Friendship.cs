using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Friendship
    {
        public int ID { get; set; }
        public string Title  { get; set; }
        public string Picure { get; set; }
        public string LinkUrl { get; set; }
        public int Sort { get; set; }
        public bool IsHide { get; set; }
        public DateTime Cdate { get;set; }
    }
}
