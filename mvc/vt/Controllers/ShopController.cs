using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace vt.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        public ActionResult Index()
        {
            return View();
        }
        //public string Cart()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    List<Models.Cart> list = Session["cart"] as List<Models.Cart>;
        //    if (list != null&&list.Count>0)
        //    {
        //        int zongjia = 0;
        //        sb.Append("<div class='c-main'>");
        //        foreach (var i in list)
        //        {
        //            zongjia += i.product.amount * i.amount;
        //            sb.Append("<div class='c-media'>");
        //            sb.Append("<input type='hidden' value='" + i.product.ID + "' class='id' />");
        //            sb.Append("<div class='me_left'>");
        //            sb.Append("<a href='/Home/prointo?id=" + i.product.ID + "'><img src='/Content/Home/image/" + i.product.Picture + "' /></a>");
        //            sb.Append("</div>");
        //            sb.Append("<div class='me_right'>");
        //            sb.Append("<h4><a href='#'>" + i.product.title + "</a></h4>");
        //            sb.Append("<div class='count_price'>");
        //            sb.Append("<span>" + i.amount + " x</span>");
        //            sb.Append("<span> " + i.product.amount + "</span>");
        //            sb.Append("</div>");
        //            sb.Append("<h5>￥" + i.product.amount + "</h5>");
        //            sb.Append("</div>");
        //            sb.Append("<a class='remove'>");
        //            sb.Append("<i class='fa fa-remove'></i>");
        //            sb.Append("</a>");
        //            sb.Append("</div>");
        //        }
        //        sb.Append("</div>");
        //        sb.Append("<div class='c-summary'>");
        //        sb.Append("<span>合计</span>");
        //        sb.Append("<span class='zongjia'>￥" + zongjia + "</span>");
        //        sb.Append("</div>");
        //        sb.Append("<div class='c-button'>");
        //        sb.Append("<a>查看购物车</a>");
        //        sb.Append("<a>结算</a>");
        //        sb.Append("</div>");
        //    }
        //    else
        //    {
        //        sb.Append("<div class='c-null'>");
        //        sb.Append("<p>购物车里还没有商品。</p>");
        //        sb.Append("</div>");
        //    }
        //    return sb.ToString();
        //}
        //[HttpGet]
        //public ActionResult addCart(int id)
        //{
        //    List<Models.Cart> Cart = Session["cart"] != null ? Session["cart"] as List<Models.Cart> : new List<Models.Cart>();
        //    var p = Cart != null ? Cart.Where(a => a.product.ID == id).FirstOrDefault() : null;
        //    if (p != null)
        //    {
        //        p.amount += 1;
        //    }
        //    else
        //    {
        //        DBModel.product pro = BLL.productbll.getmodel(id);
        //        Cart.Add(new Models.Cart() { product = pro, amount = 1 });
        //    }
        //    Session["cart"] = Cart;
        //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        //}
        //public ActionResult deleteCart(int id)
        //{
        //    List<Models.Cart> Cart = Session["cart"] != null ? Session["cart"] as List<Models.Cart> : new List<Models.Cart>();
        //    var p = Cart.Where(a => a.product.ID == id).FirstOrDefault();
        //    Cart.Remove(p);
        //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        //}
        //public ActionResult UpdateAmount(int id, int amount)
        //{
        //    List<Models.Cart> Cart = Session["cart"] != null ? Session["cart"] as List<Models.Cart> : new List<Models.Cart>();
        //    var p = Cart.Where(a => a.product.ID == id).FirstOrDefault();
        //    if (p != null)
        //    {
        //        p.amount = amount;
        //    }
        //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        //}
	}
}