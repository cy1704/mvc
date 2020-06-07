using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class productdal
    {
        static string Tname = "product";
        public static List<DBModel.product> getlist(int top,string where)
        {
            string sql = Help.strhelp.select(Tname, top, where);
            return Help.datahelp.getlist<DBModel.product>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.product getmodel(int id)
        {
            string sql = Help.strhelp.select(Tname, 0, "id=" + id);
            return Help.datahelp.getmodel<DBModel.product>(Help.sqlhelp.getdata(sql));
        }
        public static DBModel.product getmodel(string where = "")
        {
            string sql = Help.strhelp.select(Tname, 1, where);
            return Help.datahelp.getmodel<DBModel.product>(Help.sqlhelp.getdata(sql));
        }
        public static List<DBModel.product> Paging(int pageindex, int pagesize, string where)
        {
            string sql = "GetPage";
            if (!string.IsNullOrEmpty(where)){
                where = "where " + where;
            }
            SqlParameter[] p ={
                                 new SqlParameter("@field","*"),
                                 new SqlParameter("@tabname",Tname),
                                 new SqlParameter("@where",where),
                                 new SqlParameter("@order","sort"),
                                 new SqlParameter("@pageindex",pageindex),
                                 new SqlParameter("@pagesize",pagesize)
                             };
            SqlDataReader dr = Help.sqlhelp.getdata(sql, CommandType.StoredProcedure, p);
            return Help.datahelp.getlist<DBModel.product>(dr);
        }
        public static int hang(DBModel.product model)
        {
            if (model.ID > 0)
            {
                string sql = "update Product set Title=@title,Picure=@Picure,LinkUrl=@LinkUrl,Pid=@Pid,Sort=@sort,IsHide=@isHide,Cdate=@cdate,content=@Content,Isindex=@Isindex where Id=@ID";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.sort),
                                 new SqlParameter("@isHide",model.isHide),
                                 new SqlParameter("@cdate",model.CDate),
                                 new SqlParameter("@Isindex",model.Isindex),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@ID",model.ID)
                             };

                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
            else
            {
                string sql = "insert into Product (Title,Picure,LinkUrl,Pid,Sort,IsHide,Cdate,Content,Isindex) values (@title,@Picure,@LinkUrl,@Pid,@sort,@isHide,@cdate,@content,@Isindex)";
                SqlParameter[] p ={
                                 new SqlParameter("@title",model.title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.sort),
                                 new SqlParameter("@isHide",model.isHide),
                                 new SqlParameter("@cdate",model.CDate),
                                 new SqlParameter("@Isindex",model.Isindex),
                                 new SqlParameter("@content",model.Content)
                             };
                return Help.sqlhelp.execute(sql, CommandType.Text, p);
            }
        }
        public static int delete(int id)
        {
            string sql = "delete Product where Id=" + id;
            return Help.sqlhelp.execute(sql, CommandType.Text);
        }
        public static int UpdatHide(string isHide,string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(isHide));
            string sql = "update Product set IsHide=" + ss + " where id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int UpIsindex(string Isindex,string id)
        {
            int ss = Convert.ToInt32(!Convert.ToBoolean(Isindex));
            string sql = "update Product set IsIndex=" + ss + " where id=" + id;
            return Help.sqlhelp.execute(sql);
        }
    }
}
