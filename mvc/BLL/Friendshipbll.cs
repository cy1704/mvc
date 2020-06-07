using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Friendshipbll
    {
        public static List<DBModel.Friendship> getlist(int top = 0, string where = "")
        {
            return DAL.Friendshipdal.getlist(top, where);
        }
        public static DBModel.Friendship getmodel(int id)
        {
            return DAL.Friendshipdal.getmodel(id);
        }
        public static int delete(int id)
        {
            return DAL.Friendshipdal.delete(id);
        }
        public static int UpdatHide(string isHide, string id)
        {
            return DAL.Friendshipdal.UpdatHide(isHide, id);
        }
        public static int hang(DBModel.Friendship model)
        {
            return DAL.Friendshipdal.hang(model);
        }
    }
}
