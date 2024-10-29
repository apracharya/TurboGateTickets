using Microsoft.AspNetCore.Mvc;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;

namespace TurboGateTickets.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ticket> tickets = await ticketService.ReadAllTickets();
            return View(tickets);
        }
    }
}
