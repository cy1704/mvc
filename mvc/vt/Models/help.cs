using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vt.Models
{
    public class help
    {
        public static string gettyle(DBModel.column model)
        {
            switch (model.ctype)
            {
                case 0:
                    return "/Home/Index";
                case 1:
                    if (model.pid==0)
                    {
                        return "/Home/product";
                    }
                    return "/Home/product?ID=" + model.id;
                case 2:
                    if (string.IsNullOrWhiteSpace(model.LinkUrl)) return "#";
                    else return model.LinkUrl;
            }
            return "#";
        }
        public static string getTitle(int id)
        {
            var m = BLL.columnbll.getmodel(id);
            if (m!=null)
            {
                return m.title;
            }
            return "";
        }
        public static string fj(int id)
        {
            var s = "一级栏目";
            if(id==0)
            {
                return s;
            }
            s = BLL.columnbll.getmodel(id).title;
            return s;
        }
    }
}