using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Userdal
    {
        public static DBModel.User GetModel(string name,string pwd)
        {
            string sql = Help.strhelp.select("[User]", 0, "name='"+name+"' and pwd='"+pwd+"'");
            SqlDataReader dr = Help.sqlhelp.getdata(sql);
            return Help.datahelp.getmodel<DBModel.User>(dr);
        }
        public static DBModel.User GetModel(string id)
        {
            string sql = "select * from [User] where id=" + id;
            SqlDataReader dr = Help.sqlhelp.getdata(sql);
            return Help.datahelp.getmodel<DBModel.User>(dr);
        }
        public static void GetUpdate(string name, string pwd)
        {
            string sql = "update [User] set LogoCount=LogoCount+1,cdate=getdate() where name=@name and pwd=@pwd";
            SqlParameter[] p ={
                                 new SqlParameter("@name",name),
                                 new SqlParameter("@pwd",pwd)
                             };
            Help.sqlhelp.execute(sql,CommandType.Text,p);
        }
        public static List<DBModel.User> Getlist()
        {
            string sql = "select * from [User]";
            SqlDataReader dr = Help.sqlhelp.getdata(sql);
            return Help.datahelp.getlist<DBModel.User>(dr);
        }
        public static int GetDelete(int id)
        {
            string sql = "delete from [User] where id=" + id;
            return Help.sqlhelp.execute(sql);
        }
        public static int GetDeletes(string ids)
        {
            string sql = "delete from [User] where id in("+ids+")";
            return Help.sqlhelp.execute(sql);
        }
    }
}
