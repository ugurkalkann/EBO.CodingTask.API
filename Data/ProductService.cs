using EBO.CodingTask.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EBO.CodingTask.API.Data
{
    public class ProductService : IProductService
    {
        private List<Product> productList = new List<Product>();
        private List<OrderProductDetail> orderProductHistory = new List<OrderProductDetail>();
        public ProductService()
        {
            productList = new List<Product>
            {
                new Product{ ProductID = 1, Name = "Product1", Description = "Definition of Product1" },
                new Product{ ProductID = 2, Name = "Product2", Description = "Definition of Product2" },
                new Product{ ProductID = 3, Name = "Product3", Description = "" },
                new Product{ ProductID = 4, Name = "Product4", Description = "Definition of Product4" },
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productList;
        }

        public Product GetProduct(int productID)
        {
            return productList.Find(p => p.ProductID == productID);
        }

        public Product OrderProduct(OrderProductRequest request)
        {
            productList.Find(p => p.ProductID == request.ProductID).OrderCount++;
            orderProductHistory.Add(new OrderProductDetail { ProductID = request.ProductID, UserID = request.UserID, OrderDate = DateTime.Now });

            return GetProduct(request.ProductID);
        }

        public IEnumerable<OrderProductDetail> GetOrderProductHistory(int productID)
        {
            return orderProductHistory.Where(o => o.ProductID == productID).OrderByDescending(o => o.OrderDate);
        }
    }
}