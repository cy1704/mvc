using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vt.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult User(string name, string pwd, string code)
        {
            var c = Request.Cookies["code"].Value;
            if (code.ToLower() == c.ToLower())
            {
                DBModel.User model = BLL.Userbll.GetModel(name, pwd);
                if (model != null)
                {
                    BLL.Userbll.GetUpdate(name, pwd);
                    HttpContext.Session["user"] = model;
                    return RedirectToAction("Index", model);
                }
                else
                {
                    return Content("<script>alert('账号或密码错误！');history.go(-1);</script>");
                }
            }
            else
            {
                return Content("<script>alert('验证码输入错误！');history.go(-1);</script>");
            }
        }
        public ActionResult Index(DBModel.User model)
        {
            return View(model);
        }
        public ActionResult Index_Main()
        {
            return View();
        }
        public ActionResult User_Control(string where = "")
        {
            List<DBModel.User> list = new List<DBModel.User>();
            if (where == "")
            {
                list = BLL.Userbll.getlist(0,"");
            }
            else
            {
                list = BLL.Userbll.getlist(0, "Name like '%" + where + "%'");
            }
            return View(list);
        }
        public ActionResult User_Edit(string id)
        {
            DBModel.User model = new DBModel.User();
            if (id!=null)
            {
                model = BLL.Userbll.GetModel(id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult User_Edit(int id, string name, string pwd)
        {
            if (id >0)
            {
                BLL.Userbll.GetEdit(id,name, pwd);
                return Content("<script>alert('编辑成功');location.href='/Admin/User_Control'</script>");
            }
            else
            {
                BLL.Userbll.GetEdit(id, name, pwd);
                return Content("<script>alert('添加成功');location.href='/Admin/User_Control'</script>");
            }
        }
        public ActionResult User_Delete(int id)
        {
            BLL.Userbll.GetDelete(id);
            return Content("<script>alert('删除成功！');location.href='/Admin/User_Control';</script>");
        }
        [HttpPost]
        public ActionResult User_Deletes(string ids)
        {
            BLL.Userbll.GetDeletes(ids);
            return Json("批量删除成功!!!");
        }
        public ActionResult Information(string id)
        {
            DBModel.User model = BLL.Userbll.GetModel(id);
            return View(model);
        }
        public ActionResult lmgl()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult GetClass(int id = 0, string where = "")
        {
            var model = new List<DBModel.lmgl>();
            if (where == "")
            {
                model = BLL.lmglbll.Getlist(0, "pid=0");
                if (id != 0)
                {
                    model = BLL.lmglbll.Getlist(0, "pid=" + id);
                }
            }
            else
            {
                model = BLL.lmglbll.Getlist(0, "title like '%" + where + "%'");
                
            }
            return PartialView(model);
        }
        public ActionResult UpdatHide(string ishide, string id)
        {
            BLL.lmglbll.UpdatHide(ishide, id);
            return Content("<script>alert('修改成功！');location.href='/Admin/lmgl';</script>");
        }
        public ActionResult Updatelmgl()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var model = BLL.lmglbll.GetModel(id);
            if (id != 0)
            {
                BindType(model.Ctype);
            }
            else
                BindType(0);
            if (Request.QueryString["act"] != null)
            {
                ViewBag.opera = "添加栏目";
                var pid = "";
                if (id != 0)
                {
                    pid = BLL.lmglbll.GetModel(id).Title;
                }
                model = new DBModel.lmgl();
                BindClass(pid);
            }
            else
            {
                var getfuji = BLL.lmglbll.GetModel(id).Pid;
                if (getfuji > 0)
                {
                    var pid = BLL.lmglbll.GetModel(getfuji).Title;
                    BindClass(pid);
                }
                else
                {
                    BindClass();
                }
                ViewBag.opera = "编辑栏目";
            }
            return View(model);
        }
        private void BindType(int ctype)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            string[] s = { "文字列表", "图片列表", "单页信息", "其他" };
            for (int i = 0; i < 4; i++)
            {
                if (i == ctype)
                {
                    list.Add(new SelectListItem() { Text = s[i], Value = i.ToString(), Selected = true });
                }
                else
                {
                    list.Add(new SelectListItem() { Text = s[i], Value = i.ToString() });
                }
            }
            ViewBag.ctype = list;
        }
        private void BindClass(string name = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "作为顶级栏目", Value = "0" });
            BindSub(0, list, name);
            ViewBag.pid = list;
        }
        private void BindSub(int id, List<SelectListItem> list, string name)
        {
            var list2 = BLL.lmglbll.Getlist(0, "Pid=" + id + "order by Sort");
            if (list2 != null)
            {
                foreach (var l in list2)
                {
                    string s = "┣";
                    if (l.Pid != 0)
                    {
                        s = "┳";
                    }
                    if (name == l.Title)
                    {
                        list.Add(new SelectListItem() { Text = s + l.Title, Value = l.Id.ToString(), Selected = true });
                    }
                    else
                    {
                        list.Add(new SelectListItem() { Text = s + l.Title, Value = l.Id.ToString() });
                    }
                    BindSub(l.Id, list, name);
                }
            }
        }
        public ActionResult UpFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpFile(HttpPostedFileBase file)
        {
            var name = Request.Files[0].FileName;//获取文件名
            var filename = DateTime.Now.ToString("yyyymmddhhmmss") + name;
            var ext = System.IO.Path.GetExtension(name);//获取文件后缀名
            if (ext == ".jpg" || ext == ".png" || ext == ".gif")
            {
                Request.Files[0].SaveAs(Server.MapPath("~/Content/UpFile/Images/") + filename);
            }
            else
            {
                return Content("<script>alert('图片格式错误！请重新上传');history.go(-1);</script>");
            }
            //@ViewBag.picpach = filename;
            return View((object)filename);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Tijiao(DBModel.lmgl model)
        {
            //model.pid=string.IsNullOrEmpty(model.pid)
            model.LinkUrl = string.IsNullOrEmpty(model.LinkUrl) ? "" : model.LinkUrl;
            model.Picture = string.IsNullOrEmpty(model.Picture) ? "" : model.Picture;
            model.Content = string.IsNullOrEmpty(model.Content) ? "" : model.Content;
            model.Cdate = model.Cdate.Year == 1 ? DateTime.Now : model.Cdate;
            if (model.Id > 0)
            {
                if (BLL.lmglbll.ClassInsert(model) > 0)
                {
                    return Content("<script>alert('编辑成功');location.href='/Admin/lmgl'</script>");
                }
            }
            else
            {
                if (BLL.lmglbll.ClassInsert(model) > 0)
                {
                    return Content("<script>alert('添加成功');location.href='/Admin/lmgl'</script>");
                }
            }
            return null;
        }
        public ActionResult Deletelmgl(string id)
        {
            BLL.lmglbll.delete(id);
            return Content("<script>alert('删除成功！');location.href='/Admin/lmgl'</script>");
        }
        public ActionResult Product(string where="")
        {
            List<DBModel.product> Productlist = new List<DBModel.product>();
            if (where == "")
            {
                Productlist = BLL.productbll.getlist(0, "id>0 order by Sort");
            }
            else
            {
                Productlist = BLL.productbll.getlist(0, "title like '%" + where + "%'");
            }
            return View(Productlist);
        }
        public ActionResult Product_Edit(int id = 0)
        {
            DBModel.product model=new DBModel.product();
            if(id>0)
            {
                ViewBag.opera = "编辑产品";
                model=BLL.productbll.getmodel(id);
                BindProduct(model.Pid);
            }
            else
            {
                ViewBag.opera = "添加产品";
                BindProduct();
            }
            return View(model);
        }
        private void BindProduct(int pid=0)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "作为顶级栏目", Value = "0" });
            BindSubs(0, list,pid,1);
            ViewBag.pid = list;
        }
        private void BindSubs(int id,List<SelectListItem> list,int pid,int Ctype)
        {
            List<DBModel.column> list2 = BLL.columnbll.getlist(0, "pid=" + id + " and Ctype="+Ctype+" order by Sort");//找pid的等于0的
            if (list2 != null)
            {
                foreach (var l in list2)
                {
                    string s = "┣";
                    if (l.pid != 0)
                    {
                        s = "┳";
                    }
                    if (pid ==l.id)
                    {
                        list.Add(new SelectListItem() { Text = s + l.title, Value = l.id.ToString(), Selected = true });
                    }
                    else
                    {
                        list.Add(new SelectListItem() { Text = s + l.title, Value = l.id.ToString() });
                    }
                    BindSubs(l.id,list,pid,Ctype);
                }
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Product_Edit(DBModel.product model)
        {
            model.title = string.IsNullOrEmpty(model.title) ? "" : model.title;
            model.Picure = string.IsNullOrEmpty(model.Picure) ? "" : model.Picure;
            model.LinkUrl = string.IsNullOrEmpty(model.LinkUrl) ? "" : model.LinkUrl;
            model.Pid = Convert.ToInt32(model.Pid);
            model.sort = Convert.ToInt32(model.sort);
            model.isHide = Convert.ToBoolean(model.isHide);
            model.CDate = model.CDate.Year == 1 ? DateTime.Now : model.CDate;
            model.Content = string.IsNullOrEmpty(model.Content) ? "" : model.Content;
            if (model.ID > 0)
            {
                if (BLL.productbll.hang(model) > 0)
                {
                    
                    return Content("<script>alert('编辑成功');location.href='/Admin/Product'</script>");
                }
            }
            else
            {
                if (BLL.productbll.hang(model) > 0)
                {
                    
                    return Content("<script>alert('添加成功');location.href='/Admin/Product'</script>");
                }
            }
            return null;
        }
        public ActionResult Product_Delete(int id,string name="")
        {
            if(name=="")
            {
                if (BLL.productbll.delete(id) > 0)
                {
                    return Content("<script>alert('删除成功');location.href='/Admin/Product'</script>");
                }
            }
            if (name == "Journalism")
            {
                if(BLL.Journalism.delete(id)>0)
                {
                    return Content("<script>alert('删除成功');location.href='/Admin/Journalism'</script>");
                }
            }
            return null;
        }
        public ActionResult UpdatProHide(string ishide,string id,string name="")
        {
            if(name=="")
            {
                BLL.productbll.UpdatHide(ishide, id);
                return Content("<script>alert('修改成功！');location.href='/Admin/Product';</script>");
            }
            if (name == "Journalism")
            {
                BLL.Journalism.UpdatHide(ishide, id);
                return Content("<script>alert('修改成功！');location.href='/Admin/Journalism';</script>");
            }
            return null;
        }
        public ActionResult Journalism(string where = "")
        {
            List<DBModel.Journalism> model = new List<DBModel.Journalism>();
            if (where == "")
            {
                model = BLL.Journalism.getlist(0, "id>0 order by Sort");
            }
            else
            {
                model = BLL.Journalism.getlist(0, "title like '%" + where + "%'");
            }
            return View(model);
        }
        public ActionResult Journalism_Edit(int id=0)
        {
            DBModel.Journalism model = new DBModel.Journalism();
            if (id > 0)
            {
                ViewBag.opera="编辑新闻";
                model = BLL.Journalism.getmodel(id);
                BindNews(model.Pid);
            }
            else
            {
                ViewBag.opera = "添加新闻";
                BindNews();
            }
            return View(model);
        }
        public void BindNews(int pid=0)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "作为顶级栏目", Value = "0" });
            BindSubs(0, list, pid,2);
            ViewBag.pid = list;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Journalism_Edit(DBModel.Journalism model)
        {
            model.Title = string.IsNullOrEmpty(model.Title) ? "" : model.Title;
            model.Picure = string.IsNullOrEmpty(model.Picure) ? "" : model.Picure;
            model.LinkUrl = string.IsNullOrEmpty(model.LinkUrl) ? "xwzx_dj" : model.LinkUrl;
            model.Pid = Convert.ToInt32(model.Pid);
            model.Sort = Convert.ToInt32(model.Sort);
            model.IsHide = Convert.ToBoolean(model.IsHide);
            model.Cdate = model.Cdate.Year == 1 ? DateTime.Now : model.Cdate;
            model.Author = string.IsNullOrEmpty(model.Author) ? "" : model.Author;
            model.Content = string.IsNullOrEmpty(model.Content) ? "" : model.Content;
            if (model.Id > 0)
            {
                if (BLL.Journalism.hang(model) > 0)
                {

                    return Content("<script>alert('编辑成功');location.href='/Admin/Journalism'</script>");
                }
            }
            else
            {
                if (BLL.Journalism.hang(model) > 0)
                {
                    return Content("<script>alert('添加成功');location.href='/Admin/Journalism'</script>");
                }
            }
            return null;
        }
    }
}