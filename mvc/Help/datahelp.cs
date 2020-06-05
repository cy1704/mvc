using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace Help
{
    public class datahelp
    {
        public static List<T> getlist<T>(DbDataReader dr) where T:new()
        {
            if (dr.HasRows)
            {
                List<T> list = new List<T>();
                var ps = new T().GetType().GetProperties();
                while (dr.Read())
                {
                    T model = new T();
                    foreach (var p in ps)
                    {
                        p.SetValue(model, dr[p.Name] == DBNull.Value ? "" : dr[p.Name]);
                    }
                    list.Add(model);
                }
                dr.Close();
                return list;
            }
            dr.Close();
            return null;
        }
        public static T getmodel<T>(DbDataReader dr) where T:new()
        {
            if (dr.HasRows)
            {
                var ps = new T().GetType().GetProperties();
                dr.Read();
                T model = new T();
                foreach (var p in ps)
                {
                    p.SetValue(model, dr[p.Name] == DBNull.Value ? "" : dr[p.Name]);
                }
                dr.Close();
                return model;
            }
            dr.Close();
            return default(T);
        }
    }
}
