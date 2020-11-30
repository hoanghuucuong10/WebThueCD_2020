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
    public class TypeDisksController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();

        // GET: TypeDisks
        [Authorize(Roles = "Manager")]
        public ActionResult IndexTypeDisk()
        {
            return View();
        }
        [Authorize(Roles = "Manager")]
        public JsonResult GetTypeList()
        {
            List<ModelTypeDisk> value = db.Types.Select(x => new ModelTypeDisk
            {
                Id_Type = x.Id_TypeDisk,
                TypeName = x.NameType,
                RentPrice=x.RentPrice,
                MaxDate=x.MaxDate
            }).ToList();
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Manager")]
        public JsonResult GetTypeByTitle(int Id_Title)
        {
            TypeDisk vc = db.Titles.Where(x => x.Id_Title == Id_Title).First().TypeDisk;
           
            return Json(vc.NameType, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public JsonResult GetTypeById(int Id_Type)
        {
            var value = db.Types.Where(x => x.Id_TypeDisk == Id_Type).FirstOrDefault();
            if(value!=null)
            {
                var result = new
                {
                    Id_TypeDisk = value.Id_TypeDisk,
                    LateFee = value.LateFee,
                    MaxDate = value.MaxDate,
                    NameType = value.NameType,
                    RentPrice = value.RentPrice,

                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }    
                
            return null;
        }
        [Authorize(Roles = "Manager")]
        public JsonResult UpdateTypeInDatabase(int Id_Type, double RentPrice, int MaxDate)
        {
            TypeDisk d = db.Types.Where(x => x.Id_TypeDisk == Id_Type).FirstOrDefault();
            if(d!=null)
            {
                d.RentPrice = RentPrice;
                d.MaxDate = MaxDate;
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}