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
    public class ReportController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Report
        [Authorize(Roles ="Manager")]
        public ActionResult IndexReportCustomer()
        {
            return View();
        }
        public ActionResult IndexReportTitle()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        //Load dữ liệu của tất cả khách hàng
        public JsonResult GetAllCustomerList()
        {
            List<ModelCustomer> CusList = db.Customers.ToList().Select(x =>
                 new ModelCustomer
                 {
                     Id_Customer = x.Id_Customer,
                     Address = x.Address,
                     Fine = x.Fine,
                     FullName = x.FullName,
                     Phone = x.Phone,
                     //CountCDBorrow = x.orderList.Sum(y=>y.orderDetailList.Where(z=>z.Status == "CHƯA TRẢ").Count())
                     CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Count),
                     TotalRent = x.orderList.Sum(y => y.TotalRent)
                 }
                ).ToList();
            return Json(CusList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        //Load dữ liệu của khách hàng
        public JsonResult GetCustomerList()
        {
            List<ModelCustomer> CusList = db.Customers.Where(x => x.orderList.Count > 0).Select(x =>
                 new ModelCustomer
                 {
                     Id_Customer = x.Id_Customer,
                     Address = x.Address,
                     Fine = x.Fine,
                     FullName = x.FullName,
                     Phone = x.Phone,
                     //CountCDBorrow = x.orderList.Sum(y=>y.orderDetailList.Where(z=>z.Status == "CHƯA TRẢ").Count())
                     CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Count),
                     TotalRent = x.orderList.Sum(y => y.TotalRent)
                 }
                ).ToList();
            return Json(CusList, JsonRequestBehavior.AllowGet);
        }

        //Load dữ liệu của tiêu đề
        [Authorize(Roles = "Manager")]
        public JsonResult GetTitleList()
        {
            var TitleList = db.Titles.Select(x => new
            {
                Id_Title = x.Id_Title,
                Name = x.Name,
                NameType = x.TypeDisk.NameType,
                //CountCDBorrow = x.orderList.Sum(y=>y.orderDetailList.Where(z=>z.Status == "CHƯA TRẢ").Count())
                CountOfItemOnShelf = x.ItemList.Where(y => y.Status == "On-Shelf").Count(),
                CountOfItemOnHold = x.ItemList.Where(y => y.Status == "On-Hold").Count(),
                CountOfItemRented = x.ItemList.Where(y => y.Status == "Rented").Count(),

            }).ToList();

            return Json(TitleList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        //Load danh sach cac CD theo Title
        public JsonResult GetCDTitleById(int Id_Title)
        {

            var value = db.Items.Where(x => x.Titles.Id_Title == Id_Title).Select(x => new
            {
                Name = x.Titles.Name,
                TypeDisk = x.Titles.TypeDisk.NameType,
                RentPrice = x.Titles.TypeDisk.RentPrice,
                MaxDate = x.Titles.TypeDisk.MaxDate,
                Status = x.Status.Trim()
            }).ToList();

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        //Load danh sach cac CD
        public JsonResult GetCustomerById(int Id_Customer)
        {
            bool kq = false;
            try
            {
                var value = db.OrderDetails.Where(x => x.Orders.Id_Customer == Id_Customer).ToList();
                if (value != null)
                {
                    kq = true;
                    return Json(value.Select(x => new
                    {
                        Name = x.Items.Titles.Name,
                        DateRent = x.Orders.DateRent,
                        DateDue = x.DateDue,
                        //DateReturn = x.DateReturn,
                        RentFee = x.RentFee,
                        Late_Fee = x.lateFeeList.Sum(y => y.Late_Fee),
                        Status = x.Status
                    }).ToList(), JsonRequestBehavior.AllowGet);
                }
                else 
                    return null;       
            }
            catch(Exception e)
            {

            }       

            return Json(kq, JsonRequestBehavior.AllowGet);
        }
        //Tim khách hàng
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public JsonResult GetSearchingData(string SearchBy)
        {
            List<ModelCustomer> CusList = new List<ModelCustomer>();
            if (SearchBy == "0")
            {
                try
                {
                    CusList = db.Customers.Where(x => x.orderList.Count > 0).Select(x =>
                 new ModelCustomer
                 {
                     Id_Customer = x.Id_Customer,
                     Address = x.Address,
                     Fine = x.Fine,
                     FullName = x.FullName,
                     Phone = x.Phone,
                         //CountCDBorrow = x.orderList.Sum(y=>y.orderDetailList.Where(z=>z.Status == "CHƯA TRẢ").Count())
                         CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Count),
                     TotalRent = x.orderList.Sum(y => y.TotalRent)
                 }
                ).ToList();
                    return Json(CusList, JsonRequestBehavior.AllowGet);

                    //int Id = Convert.ToInt32(SearchBy);
                    //StuList = db.Customers.Where(x => x.Id_Customer == Id).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchBy);
                }
                return Json(CusList, JsonRequestBehavior.AllowGet);
            }
            else if (SearchBy == "1")
            {
                CusList = db.Customers.Where(x => x.orderList.Sum(y => y.orderDetailList.Where(z => z.DateDue < z.DateReturn).Count()) > 0).Select(x =>
                     new ModelCustomer
                     {
                         Id_Customer = x.Id_Customer,
                         Address = x.Address,
                         Fine = x.Fine,
                         FullName = x.FullName,
                         Phone = x.Phone,
                         //CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Where(z => z.LateFee > 0).Count()),
                         CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Count),
                         TotalRent = x.orderList.Sum(y => y.TotalRent)
                     }
                    ).ToList();
                return Json(CusList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                CusList = db.Customers.Where(x => x.orderList.Sum(y => y.orderDetailList.Where(z => z.RentFee > 0).Count()) > 0).Select(x =>
                     new ModelCustomer
                     {
                         Id_Customer = x.Id_Customer,
                         Address = x.Address,
                         Fine = x.Fine,
                         FullName = x.FullName,
                         Phone = x.Phone,
                         //CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Where(z => z.LateFee > 0).Count()),
                         CountCDBorrow = x.orderList.Sum(y => y.orderDetailList.Count),
                         TotalRent = x.orderList.Sum(y => y.TotalRent)
                     }
                    ).ToList();
                return Json(CusList, JsonRequestBehavior.AllowGet);
                //CusList = db.Customers.Where(x => x.FullName.StartsWith(SearchBy)).ToList();
                //return Json(CusList, JsonRequestBehavior.AllowGet);
            }

        }
    }
}