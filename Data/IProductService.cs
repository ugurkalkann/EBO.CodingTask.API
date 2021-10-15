using EBO.CodingTask.API.Models;
using System.Collections.Generic;

namespace EBO.CodingTask.API.Data
{
    interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int productID);
        Product OrderProduct(OrderProductRequest request);
        IEnumerable<OrderProductDetail> GetOrderProductHistory();
    }
}
