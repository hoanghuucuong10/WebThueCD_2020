using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THUE_CD.Models;
using THUE_CD.ViewModel;

namespace THUE_CD.Controllers
{
    public class HomeController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            HttpCookie ck = Request.Cookies["Cookies"];
            if (ck == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                string s = ck["acname"];
                if (s == null)
                {
                    return RedirectToAction("Login", "Login");
                }

            }
            ViewBag.Total = "";
            return View();
        }

        public ActionResult IndTexttex()
        {
            ViewBag.Total = "";
            return View();
        }
        public JsonResult GetCustomerById(int Id_Customer)
        {
            Customer model = db.Customers.Where(x => x.Id_Customer == Id_Customer).FirstOrDefault();

            if (model != null)
            {
                var result = new ModelCustomer()
                {
                    Id_Customer = model.Id_Customer,
                    Address = model.Address,
                    Fine = model.Fine,
                    FullName = model.FullName,
                    Phone = model.Phone
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemById(int Id_Item)
        {
            Item x = db.Items.Where(s => s.Id_Item == Id_Item).SingleOrDefault();

            if (x != null)
            {
                var result = new ModelItem()
                {
                    Id_Item = x.Id_Item,
                    Id_Title = x.Id_Title,
                    Id_TypeDisk = x.Titles.Id_TypeDisk,
                    TitleName = x.Titles.Name,
                    TypeName = x.Titles.TypeDisk.NameType,
                    Status = ItemController.GetItemStatus(x.Status.Trim()),
                    RentFee = x.Titles.TypeDisk.RentPrice,
                    LateFee = x.Titles.TypeDisk.LateFee,
                    MaxDate = x.Titles.TypeDisk.MaxDate
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemByIdOnShelf(int Id_Item)
        {
            Item x = db.Items.Where(s => s.Id_Item == Id_Item && s.Status == "On-Shelf").SingleOrDefault();

            if (x != null)
            {
                var result = new ModelItem()
                {
                    Id_Item = x.Id_Item,
                    Id_Title = x.Id_Title,
                    Id_TypeDisk = x.Titles.Id_TypeDisk,
                    TitleName = x.Titles.Name,
                    TypeName = x.Titles.TypeDisk.NameType,
                    Status = ItemController.GetItemStatus(x.Status.Trim()),
                    RentFee = x.Titles.TypeDisk.RentPrice,
                    LateFee = x.Titles.TypeDisk.LateFee,
                    MaxDate = x.Titles.TypeDisk.MaxDate
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}