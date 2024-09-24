using DOANno1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Controllers
{
    public class HomeController : Controller
    {
        public DataClasses1DataContext dbo = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["is_login"] != null)
            {
                if ((bool)Session["is_login"])
                {
                    //trường hợp đã login rồi
                    return View();
                }
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult Index2()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ql_chucvu()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult LogoutConfirmation()
        {
            string script = "if(confirm('Bạn có chắc chắn muốn đăng xuất?')){ window.location.href = '" + Url.Action("DangNhap", "TaiKhoan") + "'; }";
            return JavaScript(script);
        }
        public ActionResult Users()
        {
            if (System.Web.HttpContext.Current.Session["is_login"] != null)
            {
                if ((bool)Session["is_login"])
                {
                    return View();
                }
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

    }
}