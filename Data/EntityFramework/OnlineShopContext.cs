using EBO.CodingTask.API.Models;
using EBO.CodingTask.API.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EBO.CodingTask.API.Data
{
    public class OnlineShopContext : DbContext, IUserService, IProductService
    {
        public OnlineShopContext() : base("name=OnlineShopContext")
        {
        }

        #region Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProductDetail> Orders { get; set; }
        #endregion

        #region Product & Order Operations
        public IEnumerable<Product> GetAllProducts()
        {
            return Products.ToList();
        }

        public Product GetProduct(int productID)
        {
            return Products.Find(productID);
        }

        public Product OrderProduct(OrderProductRequest request)
        {
            Products.Find(request.ProductID).OrderCount++;
            Orders.Add(new OrderProductDetail { ProductID = request.ProductID, UserID = request.UserID, OrderDate = DateTime.Now });

            SaveChanges();

            return GetProduct(request.ProductID);
        }

        public IEnumerable<OrderProductDetail> GetOrderProductHistory(int productID)
        {
            return Orders.Where(o => o.ProductID == productID).OrderByDescending(o => o.OrderDate).ToList();
        }
        #endregion

        #region User Operations
        public AuthResponse Login(User loginRequest)
        {
            var result = new AuthResponse();
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                result.IsSuccessful = false;
                result.Message = Constants.LOGIN_ERROR_EMPTY_CREDENTIALS;
            }
            else
            {
                if (Users.Any(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password))
                {
                    result.IsSuccessful = true;
                    result.UserInfo = Users.First(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);
                    result.AuthToken = JWTUtils.CreateAuthToken();
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Message = Constants.LOGIN_ERROR_INVALID_CREDENTIALS;
                }
            }

            return result;
        }
        #endregion
    }
}