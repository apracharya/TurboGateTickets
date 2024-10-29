using TurboGateTickets.Data.Enum;
using TurboGateTickets.Models;

namespace TurboGateTickets.ViewModels
{
    public class EditRaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string TrackDescription { get; set; }
        public IFormFile TrackLayout { get; set; }
        public string? NewLayout { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RaceType RaceType { get; set; }
        public RaceCategory RaceCategory { get; set; }

    }
}
