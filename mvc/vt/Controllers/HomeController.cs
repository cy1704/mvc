using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vt.Controllers
{
    public class HomeController : Controller
    {
        public static Models.companyInfo info = Models.serialization.deserialize();
        //
        // GET: /Home/

        [HttpPost]
        public ActionResult search(int id=0,string search="")
        {
            return RedirectToAction("product", new { id = id, search = search });
        }
        public ActionResult Index()
        {
            ViewBag.proindex = BLL.columnbll.getlist(3, "pid=2 and isHide=0 order by sort");
            return View();
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Column(int colid=0)
        {
            List<DBModel.column> list = BLL.columnbll.getlist(0, "pid=" + colid + " order by sort");
            return PartialView(list);
        }
        public ActionResult proudct(int id)
        {
            List<DBModel.product> list = BLL.productbll.getlist(0, "pid=" + id + " and isHide=1 order by sort");
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.info = info;
            return PartialView();
        }
        public ActionResult productindex()
        {
            List<DBModel.product> list = BLL.productbll.getlist(9, "isIndex=1 and isHide=0 order by sort");
            return PartialView(list);
        }
        [HttpGet]
        public ActionResult getpro(int id)
        {
            DBModel.product model = BLL.productbll.getmodel(id);
            if (model!=null)
            {
                return Json(model,JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(string user, string pwd, string code)
        {
            if (code.ToUpper()==Request.Cookies["code"].Value.ToUpper())
            {
                DBModel.User model = BLL.Userbll.GetModel(user, pwd);
                if (model!=null)
                {
                    Session["admin"] = model;
                    return Content("<script>location.href='/Home/Index';</script>");
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误');history.go(-1)</script>");
                }
            }
            return Content("<script>alert('验证码错误');history.go(-1)</script>");
        }
        public ActionResult LogOut()
        {
            Session["admin"] = null;
            return Content("<script>location.href='/Home/Index'</script>");
        }

        public ActionResult product(int id=0, string search="")
        {
            string where = "";
            if (id>0)
            {
                where = "pid=" + id+" and";
            }
            where += " Title like '%" + search + "%' order by sort";
            List<DBModel.product> list = BLL.productbll.getlist(0, where);
            ViewBag.colTitle = Models.help.getTitle(id);
            return View(list);
        }

        public ActionResult Contact_Us()
        {
            return View();
        }
	}
}