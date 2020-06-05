using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Journalism
    {
        public static List<DBModel.Journalism> getlist(int top = 0, string where = "")
        {
            return DAL.Journalism.getlist(top, where);
        }
        public static DBModel.Journalism getmodel(int id)
        {
            return DAL.Journalism.getmodel(id);
        }
        public static int delete(int id)
        {
            return DAL.Journalism.delete(id);
        }
        public static int UpdatHide(string isHide, string id)
        {
            return DAL.Journalism.UpdatHide(isHide, id);
        }
        public static int hang(DBModel.Journalism model)
        {
            return DAL.Journalism.hang(model);
        }
    }
}
