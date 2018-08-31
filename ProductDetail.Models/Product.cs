using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Products.Models
{
    public class Product
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
        public string DateCreated { set; get; }
    }
}
