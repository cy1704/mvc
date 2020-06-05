using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class lmglbll
    {
        public static List<DBModel.lmgl> Getlist(int top = 0, string where = "")
        {
            return DAL.lmgldal.Getlist(top,where);
        }
        public static DBModel.lmgl GetModel(int id)
        {
            return DAL.lmgldal.GetModel(id);
        }
        public static int UpdatHide(string ishide, string id)
        {
            return DAL.lmgldal.UpdatHide(ishide, id);
        }
        public static int ClassInsert(DBModel.lmgl model)
        {
            return DAL.lmgldal.ClassInsert(model);
        }
        public static int delete(string id)
        {
            return DAL.lmgldal.delete(id);
        }
    }
}
