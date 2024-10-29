using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TurboGateTickets.Data.Enum;

namespace TurboGateTickets.Models
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // Gran Premio De Aragon
        public string Track { get; set; } // Ciudad del Motor de Aragón

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; } // Teruel, Spain

        public string TrackDescription { get; set; } // Sick track, sick race!
        public string TrackLayout { get; set; } // url here
        public DateTime StartDate { get; set; } // 2020-09-02
        public DateTime EndDate { get; set; } // 2020-09-05
        public RaceType RaceType { get; set; } // MotoGP
        public RaceCategory RaceCategory { get; set; } // GP
        public IEnumerable<Ticket>? Tickets { get; set; }



    }
}
