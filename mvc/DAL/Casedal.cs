using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class Casedal
   {
       static string Tname = "Cases";
       public static List<DBModel.Cases> getlist(int top = 0, string where = "")
       {
           string sql = Help.strhelp.select(Tname, top, where);
           return Help.datahelp.getlist<DBModel.Cases>(Help.sqlhelp.getdata(sql));
       }
       public static DBModel.Cases getmodel(int id)
       {
           string sql = Help.strhelp.select(Tname, 1, "Id=" + id);
           return Help.datahelp.getmodel<DBModel.Cases>(Help.sqlhelp.getdata(sql));
       }
       public static int delete(int id)
       {
           string sql = "delete Cases where Id=" + id;
           return Help.sqlhelp.execute(sql, CommandType.Text);
       }
       public static int UpdatHide(string isHide, string id)
       {
           int ss = Convert.ToInt32(!Convert.ToBoolean(isHide));
           string sql = "update Cases set IsHide=" + ss + " where Id=" + id;
           return Help.sqlhelp.execute(sql);
       }
       public static int hang(DBModel.Cases model)
       {
           if (model.Id > 0)
           {
               string sql = "update Cases set Title=@title,Picure=@Picure,LinkUrl=@LinkUrl,Pid=@Pid,Sort=@sort,IsHide=@isHide,Cdate=@cdate,[Content]=@Content,Market=@Market,Pirce=@Price where Id=@ID";
               SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@Isindex",model.IsIndex),
                                 new SqlParameter("@cdate",model.Cdate),
                                 new SqlParameter("@content",model.Content),
                                 new SqlParameter("@Market",model.Market),
                                 new SqlParameter("@Price",model.Pirce),
                                 new SqlParameter("@ID",model.Id)
                             };

               return Help.sqlhelp.execute(sql, CommandType.Text, p);
           }
           else
           {
               string sql = "insert into Cases (Title,Picure,LinkUrl,Pid,Sort,IsHide,Cdate,Content,Market,Pirce,Isindex) values (@title,@Picure,@LinkUrl,@Pid,@sort,@isHide,@cdate,@content,@Market,@Price,@Isindex)";
               SqlParameter[] p ={
                                 new SqlParameter("@title",model.Title),
                                 new SqlParameter("@Picure",model.Picure),
                                 new SqlParameter("@LinkUrl",model.LinkUrl),
                                 new SqlParameter("@Pid",model.Pid),
                                 new SqlParameter("@sort",model.Sort),
                                 new SqlParameter("@isHide",model.IsHide),
                                 new SqlParameter("@cdate",model.Cdate),
                                 new SqlParameter("@content",model.Content),
                                  new SqlParameter("@Isindex",model.IsIndex),
                                 new SqlParameter("@Market",model.Market),
                                 new SqlParameter("@Price",model.Pirce)
                             };
               return Help.sqlhelp.execute(sql, CommandType.Text, p);
           }
       }
       public static int UpIsindex(string Isindex, string id)
       {
           int ss = Convert.ToInt32(!Convert.ToBoolean(Isindex));
           string sql = "update Cases set IsIndex=" + ss + " where id=" + id;
           return Help.sqlhelp.execute(sql);
       }
    }
}
