using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using THUE_CD.Models;
using THUE_CD.ViewModel;
namespace THUE_CD.Controllers
{
    public class OrderDetailsController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: OrderDetails
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddOrder(string lst, string date1, string date2, int CusID)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            List<int> Lst = json_serializer.Deserialize<List<int>>(lst);

            
            Order or = new Order();
            or.DateRent = DateTime.Now;
            or.TotalRent = lst.Length;
            or.Id_Customer = CusID;
            db.Orders.Add(or);

            db.SaveChanges();

            foreach (int i in Lst)
            {
                Item x = db.Items.Where(t => t.Id_Item == i).FirstOrDefault();
                if (x != null)
                {
                   
                    OrderDetail ord = new OrderDetail();
                    ord.Id_Item = i;
                    ord.Id_Order = or.Id_Order;
                    ord.DateDue = DateTime.Now.AddDays(x.Titles.TypeDisk.MaxDate);
                    ord.DateReturn = DateTime.Now.AddDays(x.Titles.TypeDisk.MaxDate);
                    ord.Status = "Chưa Trả";
                    ord.RentFee = x.Titles.TypeDisk.RentPrice;
                    or.TotalRent += ord.RentFee;
                    db.OrderDetails.Add(ord);

                    Item it = new Item();
                    x.Status = "Rented";
                    it.Status = x.Status;
                }
                else
                {
                    break;
                }
            }

            db.SaveChanges();


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetOrDetail(int Id)
        {

            ModelDiskReturn d = new ModelDiskReturn();
            OrderDetail t = db.OrderDetails.Where(x => x.Id_Item == Id && x.Items.Status == "rented").FirstOrDefault();
            string value = string.Empty;
            if (t != null)
            {
                d.ID = t.Id_Item;
                d.Title_Name = t.Items.Titles.Name;
                d.DateRent = t.Orders.DateRent;
                d.DateDue = t.DateDue;

            }
            else
            {
                d = null;
            }
            value = JsonConvert.SerializeObject(d, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);

        }
    }
}