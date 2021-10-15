using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EBO.CodingTask.API.Models
{
    public class Product
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrderCount { get; set; }
    }

    public class OrderProductRequest
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
    }

    [Table("Orders")]
    public class OrderProductDetail
    {
        [Key]
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}