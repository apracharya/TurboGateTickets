using TurboGateTickets.Models;

namespace TurboGateTickets.Interfaces
{
    public interface ITicketService
    {
        Task<Ticket> ReadTicket(int id);
        Task<IEnumerable<Ticket>> ReadAllTickets();
        Task<Ticket> CreateTicket(Ticket model);
        bool Add(Ticket ticket);
        bool Update(Ticket ticket);
        bool Delete(Ticket ticket);
        bool Save();

    }
}
