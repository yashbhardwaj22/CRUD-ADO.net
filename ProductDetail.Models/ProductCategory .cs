
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class ProductCategory
    {
        [Required]
        public int CategoryId { set; get; }
        [Required]
        public string CategoryName { set; get; }
        [Required]
        public int IsActive { set; get; }

    }
}
