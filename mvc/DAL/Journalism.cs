using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Journalism
    {
        static string Tname = "Journalism";
        public static List<DBModel.Journalism> getlist(int top = 0, string where = "")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.Journalism>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.Journalism getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 1, "Id=" + id);
            return Help.datahelp.getmodel<DBModel.Journalism>(Help.sqlhelp.getdata(sql));
        }
        public static int delete(int id)
        {
            string sql = "delete Journalism where Id=" + id;
            return Help.sqlhelp.execute(sql, CommandType.Text);
        }
        public static int UpdatHide(string isHide, string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(isHide));
            string sql = "update Journalism set IsHide=" + ss + " where Id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int hang(DBModel.Journalism model)
        {
            if (model.Id > 0)
            {
                string sql = "update Journalism set Title=@title,Picure=@Picure,LinkUrl=@LinkUrl,Pid=@Pid,Sort=@sort,IsHide=@isHide,Cdate=@cdate,Author=@Author,[Content]=@Content where Id=@ID";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@cdate",model.Cdate),
                                 new SqlParameter("@Author",model.Author),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@ID",model.Id)
                             };

                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
            else
            {
                string sql = "insert into Journalism (Title,Picure,LinkUrl,Pid,Sort,IsHide,Cdate,Author,Content,Watch) values (@title,@Picure,@LinkUrl,@Pid,@sort,@isHide,@cdate,@Author,@content,"+1+")";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@cdate",model.Cdate),
                                 new SqlParameter("@Author",model.Author),
                                 new SqlParameter("@content",model.Content)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text,p);
            }
        }
    }
}
