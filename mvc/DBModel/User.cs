using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class User
    {
        public int id { set; get; }
        public string name { set; get; }
        public string pwd { set; get; }
        public string sex { set; get; }
        public int grade { set; get; }
        public string UserIcon { set; get; }
        public DateTime cdate { set; get; }
        public int LogoCount { set; get; }
        public string BirthDate { set; get; }
        public string Place { set; get; }
        public string name2 { set; get; }
        public string IdentityCard { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
    }
}
