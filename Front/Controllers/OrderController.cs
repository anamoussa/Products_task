using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Printing;
using X.PagedList;

namespace Front.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork<Product> _product;
        private readonly IUnitOfWork<Order> _order;
        private readonly IUnitOfWork<OrderProducts> _orderProducts;
        public OrderController(
            IUnitOfWork<Product> product,
            IUnitOfWork<OrderProducts> orderProducts,
            IUnitOfWork<Order> order
            )
        {
            _product = product;
            _order = order;
            _orderProducts = orderProducts;
        }
        public IActionResult Index(int pageIndex = 1, int pagesize = 2)
        {
            IEnumerable<Order> result = _order.Entity.GetAll();

            return View(result.ToPagedList(pageIndex, pagesize));
        }
    }
}
