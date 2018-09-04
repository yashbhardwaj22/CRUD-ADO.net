using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class SearchViewModel
    {
        public string SearchText { set; get; }
        public int ProductCategoryId { set; get; }
        public int MinRange { set; get; }
        public int MaxRange { set; get; }
    }
}
