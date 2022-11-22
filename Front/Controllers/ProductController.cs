using Core.Entities;
using Core.Interfaces;
using Front.viewModels;
using Infrastautcure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Front.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork<Product> _product;
        public ProductController(IUnitOfWork<Product> product)
        {
            _product = product;
        }

        public IActionResult Index(int pageIndex = 1, int pagesize = 3)
        {

            return View(_product.Entity.GetAll().ToPagedList(pageIndex, pagesize));
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {

            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Qauntity = model.Qauntity
            };
            _product.Entity.Insert(product);
            _product.Save();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _product.Entity.GetById(id);
            if (products == null)
            {
                return NotFound();
            }
            ProductViewModel viewmodel = new ProductViewModel
            {
                ProductId = products.ProductId,
                Name = products.Name,
                Price = products.Price,
                Qauntity = products.Qauntity


            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductViewModel model)
        {
            if (id != model.ProductId)
            {
                return NotFound();
            }

          
            try
            {
                
                Product product = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Price = model.Price,
                    Qauntity = model.Qauntity
                };
                if (product.Name != "" && product.Price != null && product.Qauntity != null)
                {
                    _product.Entity.Update(product);
                    _product.Save();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;  
            }
            return RedirectToAction(nameof(Index));
           
        }
    }
}
