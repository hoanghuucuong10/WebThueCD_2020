using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using THUE_CD.Models;
using THUE_CD.ViewModel;

namespace THUE_CD.Controllers
{
    public class LateFeeController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: LateFee
        public ActionResult IndexLateFee()
        {
            return View("Index_LateFee");
        }

        [HttpGet]
        public ActionResult IndexLateFeeCustomer(int Id_Customer)
        {
            var model = db.LateFees.Where(x => x.OrderDetails.Orders.Customers.Id_Customer == Id_Customer && x.Status == "Chưa Trả").Select(x => new ModelLateFeeCustomer()
            {
                Id_LateFee = x.Id_LateFee,
                Id_Item = x.OrderDetails.Id_Item,
                Title_Name = x.OrderDetails.Items.Titles.Name,
                Cus_Name = x.OrderDetails.Orders.Customers.FullName,
                DateRent = x.OrderDetails.Orders.DateRent,
                DateReturn = x.OrderDetails.DateReturn,
                DateDue = x.OrderDetails.DateDue,
                DateLate = x.NumOfLateDate,
                Fine = x.Late_Fee,
                Id_Customer=x.OrderDetails.Orders.Id_Customer

            }).ToList();
            return View("Index_LateFee",model);
        }

        [HttpGet]
        public JsonResult GetLateFee()
        {
            List<ModelLateFee> value = db.LateFees.Where(x => x.Status == "Chưa Trả").Select(x => new ModelLateFee
            {
                Id_LateFee = x.Id_LateFee,
                Id_Item = x.OrderDetails.Id_Item,
                Title_Name = x.OrderDetails.Items.Titles.Name,
                Cus_Name = x.OrderDetails.Orders.Customers.FullName,
                Fine = x.Late_Fee * x.NumOfLateDate

            }).ToList();
            
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        //Load danh sach cac LateFee
        public JsonResult GetLateFeeById(int Id_LateFee)
        {

            var value = db.LateFees.Where(x => x.Id_LateFee == Id_LateFee).Select(x => new
            {
                ID = x.Id_LateFee,
                Name_Title = x.OrderDetails.Items.Titles.Name,
                Cus_Name = x.OrderDetails.Orders.Customers.FullName,
                DateRent = x.OrderDetails.Orders.DateRent,
                DateReturn = x.OrderDetails.DateReturn,
                DateDue = x.OrderDetails.DateDue,
                DateLate = x.NumOfLateDate,
                Late_Fee = x.Late_Fee*x.NumOfLateDate,
            }).ToList();

            return Json(value, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveLateFee(int Id_LateFee)
        {
            LateFee lt = db.LateFees.Where(x => x.Id_LateFee == Id_LateFee && x.Status=="Chưa Trả").FirstOrDefault();
            if(lt!=null)
            {
                lt.Status = "Đã Trả";
                lt.OrderDetails.Orders.Customers.Fine -= lt.Total;
            }
            db.SaveChanges();
           
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // Tim Kiem customer theo id
        [HttpGet]
        public JsonResult GetSearchingCus(int Id_Cus)
        {

            var value = db.LateFees.Where(x => x.OrderDetails.Orders.Customers.Id_Customer== Id_Cus && x.Status == "Chưa Trả").Select(x => new 
            {
                Id_LateFee = x.Id_LateFee,
                Id_Item = x.OrderDetails.Id_Item,
                Title_Name = x.OrderDetails.Items.Titles.Name,
                Cus_Name = x.OrderDetails.Orders.Customers.FullName,
                DateRent = x.OrderDetails.Orders.DateRent,
                DateReturn = x.OrderDetails.DateReturn,
                DateDue = x.OrderDetails.DateDue,
                DateLate = x.NumOfLateDate,
                Fine = x.Late_Fee

            }).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}