using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Userbll
    {
        public static DBModel.User GetModel(string name, string pwd)
        {
            return DAL.Userdal.GetModel(name, pwd);
        }
        public static DBModel.User GetModel(string id)
        {
            return DAL.Userdal.GetModel(id);
        }
        public static void GetUpdate(string name, string pwd)
        {
            DAL.Userdal.GetUpdate(name, pwd);
        }
        public static List<DBModel.User> Getlist()
        {
            return DAL.Userdal.Getlist();
        }
        public static int GetDelete(int id)
        {
            return DAL.Userdal.GetDelete(id);
        }
        public static int GetDeletes(string ids)
        {
            return DAL.Userdal.GetDeletes(ids);
        }
    }
}