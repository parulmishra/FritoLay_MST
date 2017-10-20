using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FritoLay.Models.Repositories;
using FritoLay.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FritoLay.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepo { get; }

        //public ProductController(IProductRepository productRepository)
        //{
        //    this.productRepository = productRepository;
        //}

        public ProductController(IProductRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = thisRepo;
            }
        }
        public IActionResult Index()
        {
            return View(this.productRepo.Products);
        }
        
        public IActionResult Details(int productId)
        {
            var product = this.productRepo.Products.Where(p => p.ProductId == productId);
            return View(product);
        }

        public IActionResult Create()
        {
            ViewBag.ProductId = new SelectList(this.productRepo.Products, "ProductId", "ProductName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            this.productRepo.Save(product);
            return View("Index");
        }
    
        [HttpPost]
        public IActionResult Create(Review review)
        {
            this.productRepo.Save(review);
            return RedirectToAction("Index");
        }
    }
}
