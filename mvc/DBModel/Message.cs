using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Sort { get; set; }
        public DateTime Cdate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Type { get; set; }
        public string Content { get; set; }
    }
}
