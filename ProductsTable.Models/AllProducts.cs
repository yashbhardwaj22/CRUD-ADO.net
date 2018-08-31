using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsTable.Models
{
    public class Products
    {
        [Required]
        public int ProductID { set; get; }
        [Required]
        public string ProductName { set; get; }
        [Required]
        public int ProductPrice { set; get; }
        [Required]
        public int ProductCategoryId { set; get; }
        [Required]
        public DateTime DateCreated { set; get; }
    }
}
