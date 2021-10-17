using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EBO.CodingTask.API.Controllers
{
    public class ProductsController : ApiController
    {
        //private static readonly IProductService _productRepository = new ProductService(); //In-memory data manipulation
        private readonly IProductService _productRepository = new OnlineShopContext(); //SQL Server (EF) data manipulation

        public ProductsController() { }

        public ProductsController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

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
        [Route("api/products/GetOrderProductHistory")]
        public IEnumerable<OrderProductDetail> GetOrderProductHistory(int productID)
        {
            return _productRepository.GetOrderProductHistory(productID);
        }
    }
}
