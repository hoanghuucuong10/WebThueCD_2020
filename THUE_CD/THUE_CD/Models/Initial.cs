using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THUE_CD.Models
{
    public class Initial: System.Data.Entity.CreateDatabaseIfNotExists<ThueDiaDB>
    {
        protected override void Seed(ThueDiaDB context)
        {
            context.Types.Add(new TypeDisk {NameType="Movie",RentPrice=20000,LateFee=0,MaxDate=5 });
            context.Types.Add(new TypeDisk { NameType = "Game Disk", RentPrice = 25000, LateFee = 0, MaxDate = 10 });
            context.Types.Add(new TypeDisk { NameType = "Movie", RentPrice = 20000, LateFee = 0, MaxDate = 5 });
           

            context.Customers.Add(new Customer { FullName = "Quang Phuc", Address = "Duong quang ham", Phone = "1231546", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Tran Quang", Address = "quang ham", Phone = "1234649879", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Tran Phuc", Address = "Duong ham", Phone = "479846846", Fine = 0 });
            context.SaveChanges();

            context.Titles.Add(new Title {Name="Nhat Ky Vang Anh",CountOfItem=10,Id_TypeDisk=1 });
            context.Titles.Add(new Title { Name = "Con Tra", CountOfItem = 10, Id_TypeDisk = 2 });
            context.Titles.Add(new Title { Name = "Fast and Furious", CountOfItem = 10, Id_TypeDisk = 3 });
            context.SaveChanges();

            context.Items.Add(new Item {Id_Title = 1,Status="On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.SaveChanges();
            context.Reservations.Add(new Reservation { Id_Title = 1, Id_Customer = 1, DateCreate = DateTime.Now, Status = "on-hold" });
            context.Reservations.Add(new Reservation { Id_Title = 2, Id_Customer = 2, DateCreate = DateTime.Now, Status = "on-hold" });
            context.Reservations.Add(new Reservation { Id_Title = 3, Id_Customer = 3, DateCreate = DateTime.Now, Status = "on-hold" });
            context.SaveChanges();

            context.Orders.Add(new Order { Id_Customer = 1, TotalRent = 20000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 2, TotalRent = 20000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 3, TotalRent = 20000, DateRent = DateTime.Now });
            context.SaveChanges();

            context.OrderDetails.Add(new OrderDetail { Id_Order = 1, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "rented" });
            base.Seed(context);
        }
    }
}