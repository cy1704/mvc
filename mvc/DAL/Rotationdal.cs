using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Rotationdal
    {
        static string Tname = "Rotation";
        public static List<DBModel.Rotation> getlist(int top = 0, string where = "")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.Rotation>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.Rotation getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 1, "Id=" + id);
            return Help.datahelp.getmodel<DBModel.Rotation>(Help.sqlhelp.getdata(sql));
        }
        public static int delete(int id)
        {
            string sql = "delete Rotation where Id=" + id;
            return Help.sqlhelp.execute(sql, CommandType.Text);
        }
        public static int UpdatHide(string isHide, string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(isHide));
            string sql = "update Rotation set IsHide=" + ss + " where Id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int hang(DBModel.Rotation model)
        {
            if (model.Id > 0)
            {
                string sql = "update Rotation set Title=@title,Picure=@Picure,LinkUrl=@LinkUrl,Sort=@sort,IsHide=@isHide,[Content]=@Content,Neirong=@Neirong where Id=@ID";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@Neirong",model.Neirong),
                                 new SqlParameter("@ID",model.Id)
                             };

                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
            else
            {
                string sql = "insert into Rotation (Title,Picure,LinkUrl,Sort,IsHide,Content,Neirong) values (@title,@Picure,@LinkUrl,@sort,@isHide,@content,@Neirong)";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@Neirong",model.Neirong)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
        }
    }
}
