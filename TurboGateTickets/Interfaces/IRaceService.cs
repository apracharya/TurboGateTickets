using TurboGateTickets.Models;

namespace TurboGateTickets.Interfaces
{
    public interface IRaceService
    {
        Task<Race> CreateRace(Race race);
        Task<Race> ReadRaceById(int id);
        Task<Race> ReadRaceByIdNoTracking(int id);
        Task<IEnumerable<Race>> ReadAllRaces();
        bool Save();
        bool Update(Race race);
        bool Delete(Race race);
        bool Add(Race race);
    }
}
