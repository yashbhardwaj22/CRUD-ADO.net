
using Products.Models;
using System.Collections.Generic;


namespace DAL
{

    public interface IDBOperations
    {
        
        /// <param name="Product">AllProducts Object</param>
      
        int AddProduct(Product product);

        IEnumerable<Product> GetProduct();

    }
}

