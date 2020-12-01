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
    public class ReservationsController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Reservations
        public ActionResult IndexReservations()
        {
            return View();
        }

        //Lay danh sach title
        [HttpGet]
        public JsonResult GetReservationList()
        {
            List<ModelReservations> ReservationList = db.Reservations.Select(x => new ModelReservations
            {
                Id = x.Id_Reservation,
                Id_Title = x.Id_Title,
                Id_Customer = x.Id_Customer,
                DateCreate = x.DateCreate,
                Status = x.Status


            }).ToList();
            return Json(ReservationList, JsonRequestBehavior.AllowGet);
        }


       //Lưu đặt chổ
        [HttpPost]
        public JsonResult SaveReservationsInDatabase(string Res_Id_Title, int Res_Cus_Id_Customer)
        {
      
            var result = false;
            try
            {
                Reservation Res = new Reservation();

                Res.Id_Title = int.Parse(Res_Id_Title);
                Res.Id_Customer = Res_Cus_Id_Customer;
                Res.DateCreate = DateTime.Now;
                Res.Status = "Chưa có đĩa";
                db.Reservations.Add(Res);
                db.SaveChanges();
                result = true;

            }
            catch
            {
                throw new HttpException(404, "Add false");
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        //Load chi tiết đặt chổ
        public JsonResult GetSetReservationsListById(int Id)
        {

            var value = db.Reservations.Where(x => x.Id_Reservation == Id).Select(x => new
            {
                Name = x.Titles.Name,
                DateCreate = x.DateCreate,
                FullName = x.Customers.FullName,
                Address = x.Customers.Address,
                Phone = x.Customers.Phone,
                IdItem = db.ReserDetails.Where(s => s.Id_Reservation == x.Id_Reservation).Select(z => z.Id_Item).FirstOrDefault().ToString() ?? "",
                Status = x.Status
            }).ToList();

            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Xoa dat cho
        [HttpPost]
        public JsonResult DeleteReservationsRecord(int Id)
        {
            bool result = false;
            Reservation Res = db.Reservations.SingleOrDefault(x => x.Id_Reservation == Id);
            //Xoa chi tiet cua dat cho
            ReserDetails ResD = db.ReserDetails.Where(x => x.Id_Reservation == Id).FirstOrDefault();  
                      
            if(ResD!= null)
            {
                if (Res.Status == "Đã Có Đĩa")
                {
                    Item item = db.Items.Where(x => x.Id_Item == ResD.Id_Item).FirstOrDefault();
                    item.Status = "On-Shelf";
                }
                db.ReserDetails.Remove(ResD);
            }        
            //Xoa dat cho
            db.Reservations.Remove(Res);
            db.SaveChanges();
            result = true;

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public void PlaceOnHold(Item item)
        {
            List<Reservation> lstRe = db.Reservations.Where(x => x.Id_Title == item.Id_Title && x.Status == "Chưa Có Đĩa").ToList();
            if (lstRe != null)
            {
                Reservation re = new Reservation();
                re.Id_Reservation = int.MaxValue;
                foreach (Reservation reitem in lstRe)
                {
                    if (reitem.Id_Reservation < re.Id_Reservation)
                    {
                        re = reitem;
                    }
                }
                if(re.Id_Reservation==int.MaxValue)
                {
                    return;
                }
                item.Status = "On-Hold";
                re.Status = "Đã Có Đĩa";
                //thêm reDetail
                ReserDetails reDetail = new ReserDetails();
                reDetail.Id_Reservation = re.Id_Reservation;
                reDetail.Id_Item = item.Id_Item;
                db.ReserDetails.Add(reDetail);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public int Num()
        {
            int num = db.Reservations.Where(x => x.Status == "Đã Có Đĩa").Count();
            return num;
        }
    }
}