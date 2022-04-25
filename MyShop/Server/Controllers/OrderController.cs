using Microsoft.AspNetCore.Mvc;
using MyShop.Server.DB;
using MyShop.Shared;

namespace MyShop.Server.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductsDBContext _dbContext;
        public OrderController(ProductsDBContext ctx)
        {
            _dbContext = ctx;
        }
        [HttpPost]
        [Route("/Order")]
        public bool Order([FromBody] Order order)
        {
            if (string.IsNullOrWhiteSpace(order.Name) && string.IsNullOrWhiteSpace(order.Addres) &&
                string.IsNullOrWhiteSpace(order.Email))
            {
                return false;
            }

            try
            {
                order.Product = _dbContext.Products.FirstOrDefault(p => p.Id == order.Product.Id);
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        [HttpGet]
        [Route("/Orders")]
        public IEnumerable<Order> Orders()
        {
            return _dbContext.Orders;
        }
    }
}
