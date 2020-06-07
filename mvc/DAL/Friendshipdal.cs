using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class Friendshipdal
    {
        static string Tname = "Friendship";
        public static List<DBModel.Friendship> getlist(int top = 0, string where = "")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.Friendship>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.Friendship getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 1, "Id=" + id);
            return Help.datahelp.getmodel<DBModel.Friendship>(Help.sqlhelp.getdata(sql));
        }
        public static int delete(int id)
        {
            string sql = "delete Friendship where Id=" + id;
            return Help.sqlhelp.execute(sql, CommandType.Text);
        }
        public static int UpdatHide(string isHide, string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(isHide));
            string sql = "update Friendship set IsHide=" + ss + " where Id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int hang(DBModel.Friendship model)
        {
            if (model.ID > 0)
            {
                string sql = "update Friendship set Title=@title,Picure=@Picure,LinkUrl=@LinkUrl,Sort=@sort,IsHide=@isHide,Cdate=@cdate where Id=@ID";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@cdate",model.Cdate),
                                 new SqlParameter("@ID",model.ID)
                             };

                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
            else
            {
                string sql = "insert into Friendship (Title,Picure,LinkUrl,Sort,IsHide,Cdate) values (@title,@Picure,@LinkUrl,@sort,@isHide,@cdate)";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@cdate",model.Cdate)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
        }
    }
}
