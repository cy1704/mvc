using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace vt.Models
{
    public class serialization
    {
        public static void serialize()
        {
            string filename = HttpContext.Current.Server.MapPath("/ComInfo.bin");
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            companyInfo info = new companyInfo()
            {
                name = "YPYD布料有限公司",
                title = "湖北省仙桃市东枫英人布料有限公司",
                key = "YPYD",
                description = "",
                address = "湖北省仙桃市创源村1704班二三组第二排",
                phone = "+ 86-31-000-000",
                fax = "+ 86-31-000-000",
                code = "433000",
                email = "hello@example.com",
                website = "www.YPYD.com",
                benan = "Copyright ©2019 1704 YPYD 团队 鄂ICP备20191219"
            };
            BinaryFormatter bin=new BinaryFormatter ();
            bin.Serialize(fs,info);
            fs.Close();
        }
        public static companyInfo deserialize()
        {
            serialize();
            string filename = HttpContext.Current.Server.MapPath("/ComInfo.bin");
            FileStream fs = new FileStream(filename,FileMode.Open,FileAccess.Read);
            BinaryFormatter bin = new BinaryFormatter();
            companyInfo info = bin.Deserialize(fs) as companyInfo;
            fs.Close();
            return info;
        }
    }
    [Serializable]
    public class companyInfo
    {
        public string name { set; get; }//公司标题
        public string title { set; get; }//网站标题
        public string key { set; get; }//搜索关键字
        public string description { set; get; }//网站说明
        public string address { set; get; }//公司地址
        public string phone { set; get; }//电话
        public string fax { set; get; }//传真
        public string code { set; get; }//邮政编码（433000）
        public string email { set; get; }//电子邮件
        public string website { set; get; }//网站地址
        public string benan { set; get; }//网站备案
    }
}