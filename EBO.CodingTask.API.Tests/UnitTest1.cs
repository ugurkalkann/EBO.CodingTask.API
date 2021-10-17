using EBO.CodingTask.API.Controllers;
using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EBO.CodingTask.API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin1()
        {
            var controller = new LoginController(new UserService());

            var response = controller.Post(
                new Models.User
                {
                    Username = "User1",
                    Password = "Password1"
                });

            Assert.IsTrue(response.IsSuccessful);
        }

        [TestMethod]
        public void TestLogin2()
        {
            var controller = new LoginController(new UserService());

            var response = controller.Post(
                new Models.User
                {
                    Username = "User2",
                    Password = "Password1"
                });

            Assert.IsTrue(!response.IsSuccessful);
        }

        [TestMethod]
        public void TestLoginMessage1()
        {
            var controller = new LoginController(new UserService());

            var response = controller.Post(
                new Models.User
                {
                    Username = "User2",
                    Password = "Password1"
                });

            StringAssert.Contains(response.Message, Constants.LOGIN_ERROR_INVALID_CREDENTIALS);
        }

        [TestMethod]
        public void TestLoginMessage2()
        {
            var controller = new LoginController(new UserService());

            var response = controller.Post(
                new User
                {
                    Username = "User2",
                    Password = ""
                });

            StringAssert.Contains(response.Message, Constants.LOGIN_ERROR_EMPTY_CREDENTIALS);
        }

        [TestMethod]
        public void TestProductList()
        {
            var controller = new ProductsController(new ProductService());

            var response = controller.Get();

            CollectionAssert.AllItemsAreNotNull(response?.ToList());
        }

        [TestMethod]
        public void TestProduct()
        {
            var controller = new ProductsController(new ProductService());

            var response = controller.GetProduct(1);

            Assert.IsNotNull(response);
        }
    }
}
