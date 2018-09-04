using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

namespace Products.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly DBOperations dBOperations;
        public ProductController()
        {
            dBOperations = new DBOperations();
        }
        public IActionResult Index()
        {

            return View(dBOperations.GetProduct());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            dBOperations.AddProduct(product);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateProduct(int id)
        {
            Product product = dBOperations.GetProductID(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            dBOperations.UpdateProduct(product);
            return RedirectToAction("Index");

        }
        public IActionResult DetailsProduct(int id)
        {
            Product product = dBOperations.GetProductID(id);
            return View(product);
        }
        public IActionResult DeleteProduct(int id)
        {
            // dBOperations.DeleteProductID(id);
            if (id == null)
            {
                return NotFound();
            }
            Product product = dBOperations.GetProductID(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            dBOperations.DeleteProductID(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SearchProduct(SearchViewModel searchViewModel)
        {
            IEnumerable<Product> searchList = dBOperations.GetProduct();
            if (searchViewModel.MaxRange == 0)
            {
                searchViewModel.MaxRange = 999999999;
            }
            if (searchViewModel.SearchText == null)
            {
                searchViewModel.SearchText = "";
            }
            if (searchViewModel.ProductCategoryId != 0)
            {
                searchList = (from s in searchList
                              where s.ProductName.ToUpper().Contains(searchViewModel.SearchText.ToUpper())
                               && (s.ProductPrice >= searchViewModel.MinRange && s.ProductPrice <= searchViewModel.MaxRange)
                               && (s.ProductCategoryId.ToString().Contains(searchViewModel.ProductCategoryId.ToString()))
                              select s).ToList();
            }
            else
            {
                searchList = (from s in searchList
                              where s.ProductName.ToUpper().Contains(searchViewModel.SearchText.ToUpper())
                               && (s.ProductPrice >= searchViewModel.MinRange && s.ProductPrice <= searchViewModel.MaxRange)
                              select s).ToList();
            }

            return View(searchList);
        }
    }
}