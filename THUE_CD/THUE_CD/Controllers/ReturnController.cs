using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using THUE_CD.Models;
namespace THUE_CD.Controllers
{
    public class ReturnController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Return
        public ActionResult IndexReturn()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveDiskReturn(string lst)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            List<int> Lst = json_serializer.Deserialize<List<int>>(lst);

            OrderDetail d = new OrderDetail();
            foreach (int i in Lst)
            {
                OrderDetail o = db.OrderDetails.Where(a => a.Id_Item == i && a.Status == "Chưa Trả").FirstOrDefault();
                Item item = db.Items.Where(t => t.Id_Item == i).FirstOrDefault();
                if (o != null)
                {
                    o.Status = "Đã Trả";
                    o.DateReturn = DateTime.Now;
                    item.Status = "On-Shelf";

                    DateTime ngaytra = Convert.ToDateTime(o.DateReturn);
                    DateTime hantra = Convert.ToDateTime(o.DateDue);
                    TimeSpan Time = ngaytra - hantra;
                    int TongSoNgay = Time.Days;
                    if (TongSoNgay > 0)
                    {
                        LateFee lt = new LateFee();
                        lt.Id_OrderDetail = o.Id_OrderDetail;
                        lt.Late_Fee = o.Items.Titles.TypeDisk.LateFee;
                        lt.NumOfLateDate = TongSoNgay;
                        lt.Total = o.Items.Titles.TypeDisk.LateFee * TongSoNgay;
                        lt.Status = "Chưa Trả";
                        db.LateFees.Add(lt);
                        o.Orders.Customers.Fine += lt.Total;
                    }
                }
                else
                {
                    break;
                }
                //Kiểm tra Reservation nếu có thì thêm ReservDetail cho Reservation có id nhỏ nhất, đặt status của item = "On Hold"      
                new ReservationsController().PlaceOnHold(item);


            }
            db.SaveChanges();

            string value = string.Empty;
            value = JsonConvert.SerializeObject(d, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}