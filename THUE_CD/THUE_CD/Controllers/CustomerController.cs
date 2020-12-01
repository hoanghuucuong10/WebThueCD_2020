using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THUE_CD.Models;
using Newtonsoft.Json;
using THUE_CD.ViewModel;
using System.Data.Entity;

namespace THUE_CD.Controllers
{
    public class CustomerController : Controller
    {
        ThueDiaDB db = new ThueDiaDB();
        // GET: Customer
        public ActionResult IndexCustomer()
        {
            List<Customer> Cus = db.Customers.ToList();
            return View();

        }

        //Nut save
        [HttpPost]
        public JsonResult SaveCustomerInDatabase(int ID, string Name, string Address, string Phone)
        {
            var result = false;
            try
            {
                if (ID > 0)
                {
                    Customer Cus = db.Customers.SingleOrDefault(x => x.Id_Customer == ID);
                    Cus.FullName = Name;
                    Cus.Address = Address;
                    Cus.Phone = Phone;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Customer Cus = new Customer();
                    Cus.FullName = Name;
                    Cus.Address = Address;
                    Cus.Phone = Phone;
                    Cus.Fine = 0;


                    db.Customers.Add(Cus);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch
            {
                throw new HttpException(404, "Add false");
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetCustomerList()
        {
            List<ModelCustomer> CusList = db.Customers.Select(x =>
               new ModelCustomer
               {
                   Id_Customer = x.Id_Customer,
                   Address = x.Address,
                   Fine = x.Fine,
                   FullName = x.FullName,
                   Phone = x.Phone

               }
                ).ToList();
            return Json(CusList, JsonRequestBehavior.AllowGet);
        }
        //Chỉnh sửa
        public JsonResult GetCustomerById(int Id_Customer)
        {
            Customer model = db.Customers.Where(x => x.Id_Customer == Id_Customer).SingleOrDefault();

            ModelCustomer s = new ModelCustomer();
            s.Id_Customer = model.Id_Customer;
            s.FullName = model.FullName;
            s.Address = model.Address;
            s.Phone = model.Phone;

            string value = string.Empty;

            value = JsonConvert.SerializeObject(s, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Customers.Where(x => x.Id_Customer == id).ToList();

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }

        [HttpPost]
        public JsonResult DeleteCustomerRecord(int Id_Customer)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    bool result = false;
                    List<Order> Or = db.Orders.Where(x => x.Id_Customer == Id_Customer).ToList();
                    foreach (var item in Or)
                    {
                        List<OrderDetail> OrD = db.OrderDetails.Where(x => x.Orders.Id_Customer == Id_Customer).ToList();
                        foreach (var i in OrD)
                        {
                            if (i.Status == "Chưa Trả")
                            {
                                Item m = db.Items.Where(x => x.Id_Item == i.Id_Item).FirstOrDefault();
                                m.Status = "On-Shelf";
                            }

                            var lateFee = db.LateFees.Where(x => x.Id_OrderDetail == i.Id_OrderDetail).FirstOrDefault();
                            if (lateFee != null)
                            {
                                db.LateFees.Remove(lateFee);
                            }
                            db.OrderDetails.Remove(i);
                        }
                        db.Orders.Remove(item);
                    }
                 

                    List<Reservation> Res = db.Reservations.Where(x => x.Id_Customer == Id_Customer).ToList();
                    foreach (var item in Res)
                    {
                        List<ReserDetails> Red = db.ReserDetails.Where(x => x.Id_Reservation == item.Id_Reservation).ToList();
                        foreach (var i in Red)
                        {
                            Item m = db.Items.Where(x => x.Id_Item == i.Id_Item).FirstOrDefault();
                            m.Status = "On-Shelf";
                            db.ReserDetails.Remove(i);
                        }
                        db.Reservations.Remove(item);
                    }

                    Customer Cus = db.Customers.SingleOrDefault(x => x.Id_Customer == Id_Customer);
                    db.Customers.Remove(Cus);
                    db.SaveChanges();

                    transaction.Commit();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }

    }
}