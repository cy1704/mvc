using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Help
{
    public class sqlhelp
    {
        static SqlConnection getconn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        }
        static SqlCommand getcmd(string sql,CommandType comtype,SqlParameter[] p)
        {
            SqlConnection conn = getconn();
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (p!=null)
            {
                cmd.Parameters.AddRange(p);
            }
            cmd.CommandType = comtype;
            return cmd;
        }
        public static int execute(string sql,CommandType comtype=CommandType.Text,params SqlParameter[] p)
        {
            using (SqlCommand cmd = getcmd(sql, comtype, p)) {
                return cmd.ExecuteNonQuery();
            }
        }
        public static SqlDataReader getdata(string sql, CommandType comtype=CommandType.Text,params SqlParameter[] p)
        {
            SqlCommand cmd = getcmd(sql, comtype, p);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
