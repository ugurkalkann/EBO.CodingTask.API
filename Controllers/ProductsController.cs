using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EBO.CodingTask.API.Controllers
{
    public class ProductsController : ApiController
    {
        private static readonly IProductService _productRepository = new ProductService();

        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost]
        public Product OrderProduct([FromBody] OrderProductRequest request)
        {
            return _productRepository.OrderProduct(request);
        }

        [HttpGet]
        [Route("api/values/product/GetOrderProductHistory")]
        public IEnumerable<OrderProductDetail> GetOrderProductHistory()
        {
            return _productRepository.GetOrderProductHistory();
        }
    }
}
