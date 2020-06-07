using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Rotationbll
    {
        public static List<DBModel.Rotation> getlist(int top = 0, string where = "")
        {
            return DAL.Rotationdal.getlist(top,where);
        }
        public static DBModel.Rotation getmodel(int id)
        {
            return DAL.Rotationdal.getmodel(id);
        }
        public static int delete(int id)
        {
            return DAL.Rotationdal.delete(id);
        }
        public static int UpdatHide(string isHide, string id)
        {
            return DAL.Rotationdal.UpdatHide(isHide, id);
        }
        public static int hang(DBModel.Rotation model)
        {
            return DAL.Rotationdal.hang(model);
        }
    }
}
