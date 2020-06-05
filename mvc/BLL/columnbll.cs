using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class columnbll
    {
        public static List<DBModel.column> getlist(int top = 0, string where = "")
        {
            return DAL.columndal.getlist(top, where);
        }
        public static DBModel.column getmodel(int id)
        {
            return DAL.columndal.getmodel(id);
        }
    }
}
