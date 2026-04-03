using TypicalTechTools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TypicalTechTools.Models.Repositories;
using Microsoft.Identity.Client;

namespace TypicalTools.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string search)
        {
            //HttpContext.Session.SetString("UserName", "Romeo");
            //HttpContext.Session.SetInt32("Counter", 0);

            var products = _repository.GetProducts();

            if (!string.IsNullOrEmpty(search))
            {
                HttpContext.Session.SetString("searchProducts", search);
                products = _repository.SearchProducts(search);
            }
            return View(products);
        }
        
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        public ActionResult UpdateProduct(int id)
        {
            var product = _repository.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.Updated = DateTime.Now;
                    _repository.UpdateProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
        public ActionResult<List<Product>> ShowSearchResults(string search)
        {
            search = (string.IsNullOrWhiteSpace(search)) ? string.Empty : search;

            HttpContext.Session.SetString("productSearch", search);

            var products = _repository.SearchProducts(search);
            return View("Index", products);
             
        }
    }
}
