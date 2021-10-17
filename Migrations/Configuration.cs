using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using System.Data.Entity.Migrations;

namespace EBO.CodingTask.API.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShopContext context)
        {
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 1, Name = "Product1", Description = "Definition of Product1" });
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 2, Name = "Product2", Description = "Definition of Product2" });
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 3, Name = "Product3" });
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 4, Name = "Product4", Description = "Definition of Product4" });
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 5, Name = "Cell Phone", Description = "Apple iPhone 12 128GB White" });
            context.Products.AddOrUpdate(p => p.Name, new Product { ProductID = 6, Name = "Laptop", Description = "Dell XPS 9305 Intel Core i7 1165G7 16GB 512GB SSD" });

            context.Users.AddOrUpdate(p => p.Username, new User { UserID = 1, Username = "User1", Password = "Password1" });
            context.Users.AddOrUpdate(p => p.Username, new User { UserID = 2, Username = "User2", Password = "Password2" });
            context.Users.AddOrUpdate(p => p.Username, new User { UserID = 3, Username = "User3", Password = "Password3" });
            context.Users.AddOrUpdate(p => p.Username, new User { UserID = 4, Username = "User4", Password = "Password4" });

            context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Orders"); //Delete all order history on start
        }
    }
}
