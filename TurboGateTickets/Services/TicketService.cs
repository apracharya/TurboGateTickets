using Microsoft.EntityFrameworkCore;
using TurboGateTickets.Data;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;

namespace TurboGate.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDataContext context;

        public TicketService(AppDataContext context)
        {
            this.context = context;
        }
        public bool Add(Ticket ticket)
        {
            context.Add(ticket);
            return Save();
        }

        public Task<Ticket> CreateTicket(Ticket model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> ReadAllTickets()
        {
            return await context.Tickets.ToListAsync();
        }

        public async Task<Ticket> ReadTicket(int id)
        {
            return await context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
