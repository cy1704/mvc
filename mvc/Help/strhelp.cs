using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class strhelp
    {
        public static string select(string Tname,int top=0,string where="",string fields="*")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            if (top>0)
            {
                sb.Append("top " + top);
            }
            sb.Append(fields + " from " + Tname);
            if (!string.IsNullOrWhiteSpace(where))
            {
                sb.Append(" where " + where);
            }
            return sb.ToString();
        }
    }
}
