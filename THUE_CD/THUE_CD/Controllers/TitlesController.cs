using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THUE_CD.Models;
using THUE_CD.ViewModel;
namespace THUE_CD.Controllers
{

    public class TitlesController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Titles
        public ActionResult Index()

        {
            return View();
        }
        public JsonResult GetTitlesList()
        {
            List<ModelTitle> value = db.Titles.Select(x => new ModelTitle
            {
                Id_Title = x.Id_Title,
                TitleName = x.Name,
                Count = x.CountOfItem
                
            }).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTitleById(int Id_Title)
        {
            Title model = db.Titles.Where(x => x.Id_Title == Id_Title).SingleOrDefault();
            ModelTitle v = new ModelTitle
            {
                Id_Title = model.Id_Title,
                TitleName = model.Name,
                Id_Type = model.Id_TypeDisk,
                TypeName = model.TypeDisk.NameType,
                Count = model.CountOfItem,
                NumOnShelf = db.Items.Where(x => x.Id_Title == model.Id_Title && x.Status == "On-Shelf").Count()
            };
            string value = string.Empty;

            value = JsonConvert.SerializeObject(v, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
       

        [HttpGet]
        public JsonResult GetTitleList()
        {
            List<ModelTitle> TitleList = db.Titles.Select(model =>
               new ModelTitle
               {
                   Id_Title = model.Id_Title,
                   TitleName = model.Name,
                   Id_Type = model.Id_TypeDisk,
                   TypeName = model.TypeDisk.NameType,
                   Count = model.CountOfItem,
                   CountOnShelf = db.Items.Where(t => t.Id_Title == model.Id_Title && t.Status == "On-Shelf").Count()
               }).ToList();
            return Json(TitleList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles ="Manager")]
        public JsonResult SaveTitleInDatabase(string Name_Title, int Type)
        {
            var result = false;
            try
            {
                Title t = new Title();
                t.Name = Name_Title;
                t.Id_TypeDisk = Type;
                t.CountOfItem = 0;
                db.Titles.Add(t);
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
        [Authorize(Roles = "Manager")]
        public JsonResult DeleteTitleRecord(int Id_Title)
        {
            bool result = false;
            //Xóa danh sách item
            List<Item> lstItem = db.Items.Where(x => x.Id_Title == Id_Title).ToList();    
            foreach (Item item in lstItem)
            {
                //xóa Orderdetail
                List<int> lsOr = new List<int>();
                List<OrderDetail> LstOrd = db.OrderDetails.Where(x => x.Id_Item == item.Id_Item).ToList();
                foreach (var Ord in LstOrd)
                {
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
                db.Items.Remove(item);
            }
            List<Reservation> lstRe = db.Reservations.Where(x => x.Id_Title == Id_Title).ToList();
            foreach(Reservation re in lstRe)
            {
                foreach(ReserDetails red in db.ReserDetails.Where(x=>x.Id_Reservation==re.Id_Reservation))
                {
                    db.ReserDetails.Remove(red);
                }
                db.Reservations.Remove(re);
            }

            db.Titles.Remove(db.Titles.Where(x => x.Id_Title == Id_Title).FirstOrDefault());
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult UpdateTitle(int id)
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