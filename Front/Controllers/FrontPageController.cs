using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Front.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class FrontPageController : Controller
    {
        private readonly IUnitOfWork<Product> _product;
        public FrontPageController(IUnitOfWork<Product> product)
        {
            _product = product;
        }


        public IActionResult Index(int pageIndex = 1, int pagesize = 3)
        {

            return View(_product.Entity.GetAll().ToPagedList(pageIndex, pagesize));
        }

    }
}
