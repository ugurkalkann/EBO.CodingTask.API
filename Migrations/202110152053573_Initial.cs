using System;
using System.Data.Entity.Migrations;

namespace EBO.CodingTask.API.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderID = c.Int(nullable: false, identity: true),
                    ProductID = c.Int(nullable: false),
                    UserID = c.Int(nullable: false),
                    OrderDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.OrderID);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                    OrderCount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ProductID);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserID = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    Password = c.String(nullable: false),
                })
                .PrimaryKey(t => t.UserID);

        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
