using TurboGateTickets.Data.Enum;

namespace TurboGateTickets.Models
{
    public class Order
    {
        public int Id { get; set; }
        //public User User { get; set; }
        public double Cost { get; set; }
        public string DiscountCode { get; set; } = string.Empty;
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Notes { get; set; } = string.Empty;
        public double FinalCost { get; set; }
        public OrderStatus OrderStatus { get; set; }

    }
}
