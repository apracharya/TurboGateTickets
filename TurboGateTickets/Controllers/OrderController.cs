using Microsoft.AspNetCore.Mvc;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;

namespace TurboGateTickets.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Order> orders = await orderService.ReadAllOrders();
            return View(orders);
        }
    }
}
