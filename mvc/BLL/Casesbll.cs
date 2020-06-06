using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Casesbll
    {
        public static List<DBModel.Cases> getlist(int top = 0, string where = "")
        {
            return DAL.Casedal.getlist(top,where);
        }
        public static DBModel.Cases getmodel(int id)
        {
            return DAL.Casedal.getmodel(id);
        }
        public static int delete(int id)
        {
            return DAL.Casedal.delete(id);
        }
        public static int UpdatHide(string isHide, string id)
        {
            return DAL.Casedal.UpdatHide(isHide, id);
        }
        public static int hang(DBModel.Cases model)
        {
            return DAL.Casedal.hang(model);
        }
        public static int UpIsindex(string Isindex, string id)
        {
            return DAL.Casedal.UpIsindex(Isindex, id);
        }
    }
}
