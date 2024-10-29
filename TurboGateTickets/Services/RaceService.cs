using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using TurboGateTickets.Data;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;

namespace TurboGateTickets.Services
{
    public class RaceService : IRaceService
    {
        private readonly AppDataContext context;

        public RaceService(AppDataContext context)
        {
            this.context = context;
        }

        public bool Add(Race race)
        {
            context.Add(race);
            return Save();
        }

        public async Task<Race> CreateRace(Race race)
        {
            await context.AddAsync(race);
            await context.SaveChangesAsync();
            return race;
        }

        public bool Delete(Race race)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Race>> ReadAllRaces()
        {
            return await context.Races.ToListAsync();
        }

        public async Task<Race> ReadRaceById(int id)
        {
            return await context.Races.Include(a => a.Address).Include(t => t.Tickets).FirstOrDefaultAsync(r => r.Id == id);
            //return await context.Races.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Race> ReadRaceByIdNoTracking(int id)
        {
            return await context.Races.Include(a => a.Address).Include(t => t.Tickets)
                .AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            //return await context.Races.FirstOrDefaultAsync(r => r.Id == id);
        }

        public bool Save()
        {
            int saved = context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Race race)
        {
            context.Update(race);
            return Save();
        }
    }
}
