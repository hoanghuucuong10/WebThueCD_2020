using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THUE_CD.Models;
using THUE_CD.ViewModel;
namespace THUE_CD.Controllers
{
    public class ItemController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public static string GetItemStatus(string status)
        {
            if (status == "On-Hold")
            {
                return "Có người đặt";
            }
            if (status == "Rented")
            {
                return "Đã cho thuê";
            }

            return "Trên kệ";
        }

        public JsonResult GetItemById(int Id_Item)
        {
            Item model = db.Items.Where(x => x.Id_Item == Id_Item).SingleOrDefault();
            if (model != null)
            {
                ModelItem v = new ModelItem
                {
                    Id_Item = model.Id_Item,
                    Id_Title = model.Id_Title,
                    Id_TypeDisk = model.Titles.Id_TypeDisk,
                    TitleName = model.Titles.Name,
                    TypeName = model.Titles.TypeDisk.NameType,
                    Status = GetItemStatus(model.Status),
                    RentFee = model.Titles.TypeDisk.RentPrice,
                    LateFee = model.Titles.TypeDisk.LateFee,
                    MaxDate = model.Titles.TypeDisk.MaxDate

                };
                string value = string.Empty;

                value = JsonConvert.SerializeObject(v, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(value, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetItemList()
        {
            List<ModelItem> ItemList = db.Items.Select(x =>
               new ModelItem
               {
                   Id_Item = x.Id_Item,
                   Id_Title = x.Id_Title,
                   Id_TypeDisk = x.Titles.Id_TypeDisk,
                   TitleName = x.Titles.Name,
                   TypeName = x.Titles.TypeDisk.NameType,
                   Status = x.Status,
                   RentFee = x.Titles.TypeDisk.RentPrice,
                   LateFee = x.Titles.TypeDisk.LateFee,
                   MaxDate = x.Titles.TypeDisk.MaxDate
               }).ToList();

            foreach(var x in ItemList)
            {
                x.Status = GetItemStatus(x.Status);
            }

            return Json(ItemList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateItemInDatabase(int Id_Item, int Id_Title, string Status)
        {
            var result = false;
            try
            {
                Item item = db.Items.SingleOrDefault(x => x.Id_Item == Id_Item);
                item.Id_Title = Id_Title;
                item.Status = Status;
                db.SaveChanges();
                result = true;
            }
            catch
            {
                throw new HttpException(404, "Add false");
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddItemInDatabase(int Id_Title)
        {
            var result = false;
            try
            {
                Item t = new Item();
                t.Id_Title = Id_Title;
                t.Status = "On-Shelf";
                Title ax = db.Titles.Where(x => x.Id_Title == Id_Title).FirstOrDefault();
                ax.CountOfItem++;
                db.Items.Add(t);
                db.SaveChanges();
                result = true;
            }
            catch
            {
                throw new HttpException(404, "Add false");
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteItemRecord(int Id_Item)
        {

            bool a = deleteItem(Id_Item);

            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public bool deleteItem(int Id_Item)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Item It = db.Items.SingleOrDefault(x => x.Id_Item == Id_Item);
                    if (It == null)
                        return false;
                    //Xóa OrderDetail
                    List<int> lsOr = new List<int>();
                    List<OrderDetail> LstOrd = db.OrderDetails.Where(x => x.Id_Item == Id_Item).ToList();
                    foreach (var Ord in LstOrd)
                    {
                        if (!lsOr.Contains(Ord.Id_Order))
                            lsOr.Add(Ord.Id_Order);
                        db.OrderDetails.Remove(Ord);
                    }

                    //Xóa Order
                    foreach (var i in lsOr)
                    {
                        Order or = db.Orders.Where(x => x.Id_Order == i).FirstOrDefault();
                        if (or != null)
                            db.Orders.Remove(or);
                    }


                    //giảm số lượng bản sao của tựa đĩa
                    Title Ti = db.Titles.Where(x => x.Id_Title == It.Id_Title).FirstOrDefault();
                    Ti.CountOfItem--;

                    //xóa reservation
                    List<int> lstRe = new List<int>();
                    List<ReserDetails> LstRed = db.ReserDetails.Where(x => x.Id_Item == Id_Item).ToList();
                    foreach (var Red in LstRed)
                    {
                        if(!lstRe.Contains(Red.Id_Reservation))
                            lstRe.Add(Red.Id_Reservation);
                        db.ReserDetails.Remove(Red);
                    }
                    foreach (var i in lstRe)
                    {
                        Reservation re = db.Reservations.Where(x => x.Id_Reservation == i).FirstOrDefault();
                        if (re != null)
                            db.Reservations.Remove(re);
                    }
                    //xóa item
                    db.Items.Remove(It);
                    db.SaveChanges();
                    
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }        
        }





        [HttpPost]
        public ActionResult UpdateItem(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Items.Where(x => x.Id_Item == id).ToList();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }
    }
}