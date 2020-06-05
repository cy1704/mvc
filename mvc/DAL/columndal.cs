using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class columndal
    {
        static string Tname = "[column]";
        public static List<DBModel.column> getlist(int top=0,string where="")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.column>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.column getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 1, "id=" + id);
            return Help.datahelp.getmodel<DBModel.column>(Help.sqlhelp.getdata(sql));
        }
    }
}
