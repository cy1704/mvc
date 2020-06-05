using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class lmgldal
    {
        static string Tname = "[Column]";
        public static List<DBModel.lmgl> Getlist(int top = 0, string where = "")
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.lmgl>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.lmgl GetModel(int id)
        {
            string sql = "select * from [Column] where id="+id;
            return Help.datahelp.getmodel<DBModel.lmgl>(Help.sqlhelp.getdata(sql));
        }
        public static int UpdatHide(string ishide,string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(ishide));
            string sql = "update [Column] set IsHide="+ss+" where id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int ClassInsert(DBModel.lmgl model)
        {
            if (model.Id > 0)
            {
                string sql = "update [Column] set title=@title,pid=@pid,ctype=@ctype,sort=@sort,isHide=@isHide,content=@content,linkurl=@linkurl,Picture=@picpath,cdate=@cdate where id=@id";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@pid",model.Pid),
                                 new SqlParameter("@ctype",model.Ctype),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@linkurl",model.LinkUrl),
                                 new SqlParameter("@picpath",model.Picture),
                                 new SqlParameter("@id",model.Id),
                                 new SqlParameter("@cdate",model.Cdate)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
            else
            {
                string sql = "insert into [Column] (title,pid,ctype,sort,isHide,content,linkurl,Picture,cdate) values (@title,@pid,@ctype,@sort,@isHide,@content,@linkurl,@picpath,@cdate)";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@pid",model.Pid),
                                 new SqlParameter("@ctype",model.Ctype),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@linkurl",model.LinkUrl),
                                 new SqlParameter("@picpath",model.Picture),
                                 new SqlParameter("@cdate",model.Cdate)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
        }
        public static int delete(string id)
        {
            string sql = "delete from [Column] where id=" + id;
            return Help.sqlhelp.execute(sql);
        }
    }
}
