namespace THUE_CD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id_Account = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        PassWord = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id_Account);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id_Customer = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fine = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Customer);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id_Order = c.Int(nullable: false, identity: true),
                        Id_Customer = c.Int(nullable: false),
                        TotalRent = c.Double(nullable: false),
                        DateRent = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Order)
                .ForeignKey("dbo.Customers", t => t.Id_Customer, cascadeDelete: true)
                .Index(t => t.Id_Customer);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id_OrderDetail = c.Int(nullable: false, identity: true),
                        Id_Order = c.Int(nullable: false),
                        Id_Item = c.Int(nullable: false),
                        DateReturn = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        RentFee = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id_OrderDetail)
                .ForeignKey("dbo.Items", t => t.Id_Item, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Id_Order, cascadeDelete: true)
                .Index(t => t.Id_Order)
                .Index(t => t.Id_Item);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id_Item = c.Int(nullable: false, identity: true),
                        Id_Title = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id_Item)
                .ForeignKey("dbo.Titles", t => t.Id_Title, cascadeDelete: true)
                .Index(t => t.Id_Title);
            
            CreateTable(
                "dbo.ReserDetails",
                c => new
                    {
                        Id_ReserDetail = c.Int(nullable: false, identity: true),
                        Id_Item = c.Int(nullable: false),
                        Id_Reservation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_ReserDetail)
                .ForeignKey("dbo.Items", t => t.Id_Item, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.Id_Reservation, cascadeDelete: false)
                .Index(t => t.Id_Item)
                .Index(t => t.Id_Reservation);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id_Reservation = c.Int(nullable: false, identity: true),
                        Id_Title = c.Int(nullable: false),
                        Id_Customer = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id_Reservation)
                .ForeignKey("dbo.Customers", t => t.Id_Customer, cascadeDelete: true)
                .ForeignKey("dbo.Titles", t => t.Id_Title, cascadeDelete: true)
                .Index(t => t.Id_Title)
                .Index(t => t.Id_Customer);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id_Title = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountOfItem = c.Int(nullable: false),
                        Id_TypeDisk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Title)
                .ForeignKey("dbo.TypeDisks", t => t.Id_TypeDisk, cascadeDelete: true)
                .Index(t => t.Id_TypeDisk);
            
            CreateTable(
                "dbo.TypeDisks",
                c => new
                    {
                        Id_TypeDisk = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                        RentPrice = c.Double(nullable: false),
                        LateFee = c.Double(nullable: false),
                        MaxDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_TypeDisk);
            
            CreateTable(
                "dbo.LateFees",
                c => new
                    {
                        Id_LateFee = c.Int(nullable: false, identity: true),
                        Id_OrderDetail = c.Int(nullable: false),
                        Late_Fee = c.Double(nullable: false),
                        NumOfLateDate = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id_LateFee)
                .ForeignKey("dbo.OrderDetails", t => t.Id_OrderDetail, cascadeDelete: true)
                .Index(t => t.Id_OrderDetail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Id_Order", "dbo.Orders");
            DropForeignKey("dbo.LateFees", "Id_OrderDetail", "dbo.OrderDetails");
            DropForeignKey("dbo.ReserDetails", "Id_Reservation", "dbo.Reservations");
            DropForeignKey("dbo.Titles", "Id_TypeDisk", "dbo.TypeDisks");
            DropForeignKey("dbo.Reservations", "Id_Title", "dbo.Titles");
            DropForeignKey("dbo.Items", "Id_Title", "dbo.Titles");
            DropForeignKey("dbo.Reservations", "Id_Customer", "dbo.Customers");
            DropForeignKey("dbo.ReserDetails", "Id_Item", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "Id_Item", "dbo.Items");
            DropForeignKey("dbo.Orders", "Id_Customer", "dbo.Customers");
            DropIndex("dbo.LateFees", new[] { "Id_OrderDetail" });
            DropIndex("dbo.Titles", new[] { "Id_TypeDisk" });
            DropIndex("dbo.Reservations", new[] { "Id_Customer" });
            DropIndex("dbo.Reservations", new[] { "Id_Title" });
            DropIndex("dbo.ReserDetails", new[] { "Id_Reservation" });
            DropIndex("dbo.ReserDetails", new[] { "Id_Item" });
            DropIndex("dbo.Items", new[] { "Id_Title" });
            DropIndex("dbo.OrderDetails", new[] { "Id_Item" });
            DropIndex("dbo.OrderDetails", new[] { "Id_Order" });
            DropIndex("dbo.Orders", new[] { "Id_Customer" });
            DropTable("dbo.LateFees");
            DropTable("dbo.TypeDisks");
            DropTable("dbo.Titles");
            DropTable("dbo.Reservations");
            DropTable("dbo.ReserDetails");
            DropTable("dbo.Items");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
