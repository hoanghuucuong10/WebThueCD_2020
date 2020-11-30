namespace THUE_CD.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<THUE_CD.Models.ThueDiaDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(THUE_CD.Models.ThueDiaDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Types.Add(new TypeDisk { NameType = "Movie", RentPrice = 20000, LateFee = 5000, MaxDate = 5 });
            context.Types.Add(new TypeDisk { NameType = "Game Disk", RentPrice = 25000, LateFee = 5000, MaxDate = 5 });


            //1-8
            context.Customers.Add(new Customer { FullName = "Trần Quang Phúc", Address = "Duong quang ham", Phone = "1231546", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Quang Phúc Trần", Address = "quang ham", Phone = "1234649879", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Hoàng Hữu Cương", Address = "Duong ham", Phone = "479846846", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Phan Hữu Quý", Address = "Duong quang ham", Phone = "1231546", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Lê Thành Kỷ", Address = "Duong ham", Phone = "479846846", Fine = 0 });
            context.Customers.Add(new Customer { FullName = "Hồ Trần Như", Address = "Duong quang ham", Phone = "1231546", Fine = 50000 });
            context.Customers.Add(new Customer { FullName = "Nguyễn Văn Hiền", Address = "Duong ham", Phone = "479846846", Fine = 100000 });
            context.Customers.Add(new Customer { FullName = "Nguyễn Đình Thuận", Address = "Duong quang ham", Phone = "1231546", Fine = 0 });

            context.SaveChanges();

            context.Titles.Add(new Title { Name = "Nhat Ky Vang Anh", CountOfItem = 8, Id_TypeDisk = 1 });
            context.Titles.Add(new Title { Name = "Con Tra", CountOfItem = 8, Id_TypeDisk = 2 });
            context.Titles.Add(new Title { Name = "Fast and Furious", CountOfItem = 8, Id_TypeDisk = 2 });
            context.Titles.Add(new Title { Name = "Avenger 1", CountOfItem = 8, Id_TypeDisk = 1 });
            context.Titles.Add(new Title { Name = "Avenger 2", CountOfItem = 8, Id_TypeDisk = 1 });
            context.Titles.Add(new Title { Name = "Avenger 3", CountOfItem = 8, Id_TypeDisk = 1 });
            context.Titles.Add(new Title { Name = "Rockman", CountOfItem = 8, Id_TypeDisk = 2 });
            context.Titles.Add(new Title { Name = "Đua Xe", CountOfItem = 8, Id_TypeDisk = 2 });
            context.SaveChanges();

            context.Items.Add(new Item { Id_Title = 1, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 4, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 5, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 6, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 7, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 8, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 1, Status = "Rented" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Hold" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 1, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 2, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 3, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 4, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 5, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 6, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 7, Status = "On-Shelf" });
            context.Items.Add(new Item { Id_Title = 8, Status = "On-Shelf" });
            context.SaveChanges();

            context.Reservations.Add(new Reservation { Id_Title = 1, Id_Customer = 1, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.Reservations.Add(new Reservation { Id_Title = 2, Id_Customer = 2, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.Reservations.Add(new Reservation { Id_Title = 3, Id_Customer = 3, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.Reservations.Add(new Reservation { Id_Title = 1, Id_Customer = 2, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.Reservations.Add(new Reservation { Id_Title = 2, Id_Customer = 3, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.Reservations.Add(new Reservation { Id_Title = 3, Id_Customer = 1, DateCreate = DateTime.Now, Status = "Đã Có Đĩa" });
            context.SaveChanges();

            context.ReserDetails.Add(new ReserDetails { Id_Item = 1, Id_Reservation = 1 });
            context.ReserDetails.Add(new ReserDetails { Id_Item = 2, Id_Reservation = 2 });
            context.ReserDetails.Add(new ReserDetails { Id_Item = 3, Id_Reservation = 3 });
            context.ReserDetails.Add(new ReserDetails { Id_Item = 17, Id_Reservation = 4 });
            context.ReserDetails.Add(new ReserDetails { Id_Item = 18, Id_Reservation = 5 });
            context.ReserDetails.Add(new ReserDetails { Id_Item = 19, Id_Reservation = 6 });
            context.SaveChanges();

            context.Orders.Add(new Order { Id_Customer = 5, TotalRent = 90000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 5, TotalRent = 90000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 5, TotalRent = 90000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 5, TotalRent = 90000, DateRent = DateTime.Now });
            context.Orders.Add(new Order { Id_Customer = 6, TotalRent = 20000, DateRent = Convert.ToDateTime("2020-06-30") });
            context.Orders.Add(new Order { Id_Customer = 6, TotalRent = 20000, DateRent = Convert.ToDateTime("2020-06-30") });
            context.Orders.Add(new Order { Id_Customer = 6, TotalRent = 20000, DateRent = Convert.ToDateTime("2020-06-30") });
            context.Orders.Add(new Order { Id_Customer = 7, TotalRent = 90000, DateRent = Convert.ToDateTime("2020-06-30") });

            context.SaveChanges();

            //1-4
            context.OrderDetails.Add(new OrderDetail { Id_Order = 1, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 1, Id_Item = 2, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 1, Id_Item = 3, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 1, Id_Item = 4, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            //5-8
            context.OrderDetails.Add(new OrderDetail { Id_Order = 2, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 2, Id_Item = 2, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 2, Id_Item = 3, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 2, Id_Item = 4, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            //9-12
            context.OrderDetails.Add(new OrderDetail { Id_Order = 3, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 3, Id_Item = 2, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 3, Id_Item = 3, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 3, Id_Item = 4, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            //13-16
            context.OrderDetails.Add(new OrderDetail { Id_Order = 4, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 4, Id_Item = 2, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 4, Id_Item = 3, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 4, Id_Item = 4, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            //17-18  
            context.OrderDetails.Add(new OrderDetail { Id_Order = 5, Id_Item = 4, DateReturn = DateTime.Now, DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 20000, Status = "Chưa Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 5, Id_Item = 5, DateReturn = DateTime.Now, DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 20000, Status = "Chưa Trả" });
            //19-20
            context.OrderDetails.Add(new OrderDetail { Id_Order = 6, Id_Item = 6, DateReturn = DateTime.Now, DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 20000, Status = "Chưa Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 6, Id_Item = 7, DateReturn = DateTime.Now, DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 25000, Status = "Chưa Trả" });
            //21-24
            context.OrderDetails.Add(new OrderDetail { Id_Order = 7, Id_Item = 8, DateReturn = Convert.ToDateTime("2020-07-4"), DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 25000, Status = "Chưa Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 7, Id_Item = 9, DateReturn = Convert.ToDateTime("2020-07-4"), DateDue = Convert.ToDateTime("2020-07-9"), RentFee = 20000, Status = "Chưa Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 7, Id_Item = 10, DateReturn = Convert.ToDateTime("2020-07-10"), DateDue = Convert.ToDateTime("2020-07-5"), RentFee = 25000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 7, Id_Item = 1, DateReturn = Convert.ToDateTime("2020-07-10"), DateDue = Convert.ToDateTime("2020-07-5"), RentFee = 20000, Status = "Đã Trả" });
            //25-28 trả trễ đã thanh toán
            context.OrderDetails.Add(new OrderDetail { Id_Order = 8, Id_Item = 1, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 8, Id_Item = 2, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 8, Id_Item = 3, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.OrderDetails.Add(new OrderDetail { Id_Order = 8, Id_Item = 4, DateReturn = DateTime.Now, DateDue = DateTime.Now, RentFee = 20000, Status = "Đã Trả" });
            context.SaveChanges();

           
            context.LateFees.Add(new LateFee { Id_OrderDetail = 23, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Chưa Trả" });
            context.LateFees.Add(new LateFee { Id_OrderDetail = 24, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Chưa Trả" });

            context.LateFees.Add(new LateFee { Id_OrderDetail = 25, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Đã Trả" });
            context.LateFees.Add(new LateFee { Id_OrderDetail = 26, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Đã Trả" });
            context.LateFees.Add(new LateFee { Id_OrderDetail = 27, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Đã Trả" });
            context.LateFees.Add(new LateFee { Id_OrderDetail = 28, Late_Fee = 5000, NumOfLateDate = 5, Total = 25000, Status = "Đã Trả" });
            context.SaveChanges();

            //Account
            context.Accounts.Add(new Accounts { AccountName = "Admin", PassWord = "123", Role = "Manager" });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
