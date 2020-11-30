using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using THUE_CD.Models;

namespace THUE_CD.Controllers
{
    public class LoginController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string PassWord)
        {
            var checkLogin = db.Accounts.Where(x => x.AccountName == UserName && x.PassWord == PassWord).Select(x => x.Id_Account).Any();    
            if(checkLogin)
            {
                FormsAuthentication.SetAuthCookie(UserName,false);
                //lưu thông tin cookies
                //tạo cookies
                HttpCookie ck = new HttpCookie("Cookies");
                ck["acname"] = UserName;
                Response.Cookies.Add(ck);
                ck.Expires = DateTime.Now.AddDays(3); //giới hạn thời gian 3 ngày
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            return Json("False", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            if (Request.Cookies["Cookies"] != null)//xóa cookies
            {
                FormsAuthentication.SignOut();
                HttpCookie myCookie = new HttpCookie("Cookies");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            HttpCookie ck = Request.Cookies["Cookies"];
            if (ck == null)
            {
                return null;
            }
            else
            {
                string s = ck["acname"];
                if (s != null)
                {
                    var role = db.Accounts.FirstOrDefault(x => x.AccountName == s).Role;
                    return Json(role, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
        }
    }
}