using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Messagebll
    {
        public static List<DBModel.Message> getlist(int top = 0, string where = "")
        {
            return DAL.Messagedal.getlist(top, where);
        }
        public static DBModel.Message getmodel(int id)
        {
            return DAL.Messagedal.getmodel(id);
        }
        public static int delete(int id)
        {
            return DAL.Messagedal.delete(id);
        }
        public static int hang(DBModel.Message model)
        {
            return DAL.Messagedal.hang(model);
        }
    }
}
