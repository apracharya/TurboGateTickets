using TurboGateTickets.Data.Enum;

namespace TurboGateTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Race Race { get; set; }
        public TicketType TicketType { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? CustomerName { get; set; } = "";
        public string? CustomerEmail { get; set; } = "";
        public string? CustomerPhone { get; set; } = "";
        public string? CustomerCity { get; set; } = "";
        public int? OrderId { get; set; }
        public bool Parking { get; set; }
        public string? SpecialRequest { get; set; } = "";

    }
}
