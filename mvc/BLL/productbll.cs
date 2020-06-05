using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class productbll
    {
        public static List<DBModel.product> getlist(int top, string where)
        {
            return DAL.productdal.getlist(top, where);
        }
        public static DBModel.product getmodel(int id)
        {
            return DAL.productdal.getmodel(id);
        }
        public static DBModel.product getmodel(string where = "")
        {
            return DAL.productdal.getmodel(where);
        }
        public static List<DBModel.product> Paging(int pageindex, int pagesize, string where)
        {
            return DAL.productdal.Paging(pageindex, pagesize, where);
        }
        public static int hang(DBModel.product model)
        {
            return DAL.productdal.hang(model);
        }
        public static int delete(int id)
        {
            return DAL.productdal.delete(id);
        }
        public static int UpdatHide(string isHide,string id)
        {
            return DAL.productdal.UpdatHide(isHide,id);
        }
    }
}
