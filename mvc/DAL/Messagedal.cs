using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class Messagedal
    {
        static string Tname = "Messages";
        public static List<DBModel.Message> getlist(int top = 0, string where = "")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.Message>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.Message getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 1, "Id=" + id);
            return Help.datahelp.getmodel<DBModel.Message>(Help.sqlhelp.getdata(sql));
        }
        public static int delete(int id)
        {
            string sql = "delete Messages where Id=" + id;
            return Help.sqlhelp.execute(sql, CommandType.Text);
        }
        public static int hang(DBModel.Message model)
        {
            string sql = "insert into Messages (Name,Phone,Sort,Cdate,Email,Address,Type,Content) values (@title,@Phone,@Sort,@Cdate,@Email,@Address,@Type,@content)";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Name),
                                 new SqlParameter("@Phone",model.Phone),
                                 new SqlParameter("@Sort",model.Sort),
                                 new SqlParameter("@Cdate",model.Cdate),
                                 new SqlParameter("@Email",model.Email),
                                 new SqlParameter("@Address",model.Address),
                                 new SqlParameter("@Type",model.Type),
                                 new SqlParameter("@content",model.Content)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
        }
    }
}
