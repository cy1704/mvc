using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
   public class Rotation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picure { get; set; }
        public string LinkUrl { get; set; }
        public int Sort { get; set; }
        public bool IsHide { get; set; }
        public string Content { get; set; }
        public string Neirong { get; set; }
    }
}
