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
        public IActionResult Edit(int id)
        {
            Product product = dBOperations.GetProductID(id);
            return View(product);
        }
        
        public IActionResult Update()
        {
           // int row = dBOperations.UpdateProduct(product);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            Product product = dBOperations.GetProductID(id);
            return View(product);
        }
    }
}