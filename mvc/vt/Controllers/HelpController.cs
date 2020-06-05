using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
namespace vt.Controllers
{
    public class HelpController : Controller
    {
        private string GetCode()
        {
            string a = "0123456789abcdefghijklmnopqrstuvwsyzABCDEFGHIJKLMNOPQRSTUVWSYZ";
            string s = "";
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                s += a[r.Next(a.Length)];
            }
            return s;
        }
        public void CreateImg()
        {
            Bitmap img = new Bitmap(45, 20);
            Graphics g = Graphics.FromImage(img);
            g.FillRectangle(Brushes.BurlyWood, 0, 0, img.Width, img.Height);
            string c = GetCode();
            HttpContext.Response.Cookies["code"].Value = c;
            g.DrawString(c, new Font("宋体", 14, FontStyle.Italic), Brushes.Blue, 0, 0);
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = r.Next(img.Width);
                int y = r.Next(img.Height);
                img.SetPixel(x, y, Color.FromArgb(r.Next(255)));
            }
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
	}
}