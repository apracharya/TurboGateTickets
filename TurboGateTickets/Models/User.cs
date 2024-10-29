using System.ComponentModel.DataAnnotations.Schema;

namespace TurboGateTickets.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public UserAddress Address { get; set; } // Navdeep Tole, Imadol, 44075, Bagmati, Spain
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
