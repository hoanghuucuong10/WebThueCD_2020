using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using THUE_CD.Models;
namespace THUE_CD.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }

        public int CheckUser(string username, string password, string role)
        {
            using (var db = new ThueDiaDB())
            {
                if (role == "Manager")
                {
                    var kq = db.Accounts.Where(x => x.AccountName == username
                    && x.PassWord == password && x.Role == "Manager").ToList<Accounts>();
                    if (kq.Count() > 0)
                    {
                        return 1;
                    }
                }
                if (role == "Clerk")
                {
                    var kq = db.Accounts.Where(x => x.AccountName == username
                    && x.PassWord == password && x.Role == "Clerk").ToList<Accounts>();
                    if (kq.Count() > 0)
                    {
                        return 2;
                    }
                }

                return 0;
            }
        }
        [HttpPost]
        public JsonResult LogInModal(string AcName, string Password)
        {
            if (CheckUser(AcName, Password, "Manager") == 1)
            {
                //lưu thông tin cookies
                //tạo cookies
                HttpCookie ck = new HttpCookie("Cookies");
                ck["acname"] = AcName;
                Response.Cookies.Add(ck);
                ck.Expires = DateTime.Now.AddDays(3); //giới hạn thời gian 3 ngày
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(2, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult LogOutModal()
        {
            if (Request.Cookies["Cookies"] != null)//xóa cookies
            {
                HttpCookie myCookie = new HttpCookie("Cookies");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return Json(1, JsonRequestBehavior.AllowGet);

        }

    }

}

