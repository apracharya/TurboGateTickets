using Microsoft.AspNetCore.Mvc;
using TurboGateTickets.Data;
using TurboGateTickets.Data.Enum;
using TurboGateTickets.Interfaces;
using TurboGateTickets.Models;
using TurboGateTickets.ViewModels;

namespace TurboGateTickets.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceService raceService;

        private readonly IPhotoService photoService;

        public RaceController(IRaceService raceService, IPhotoService photoService)
        {
            this.raceService = raceService;
            this.photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await raceService.ReadAllRaces();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await raceService.ReadRaceById(id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if(ModelState.IsValid)
            {
                var result = await photoService.AddPhoto(raceVM.TrackLayout);

                Race race = new Race
                {
                    Name = raceVM.Name,
                    Track = raceVM.Track,
                    StartDate = raceVM.StartDate,
                    EndDate = raceVM.EndDate,
                    Address = new Address
                    {
                        City = raceVM.Address.City,
                        State = raceVM.Address.State,
                        Country = raceVM.Address.Country

                    },
                    TrackLayout = result.Url.ToString(),
                    TrackDescription = raceVM.TrackDescription
                };
                raceService.Add(race);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }
            return View(raceVM);
        }

        public async Task<IActionResult> Ticket(int id)
        {
            Race race = await raceService.ReadRaceById(id);
            return View(race);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            Race race = await raceService.ReadRaceById(id);
            if(race == null) return View("Error");
            EditRaceViewModel raceVM = new EditRaceViewModel
            {
                Name = race.Name,
                Track = race.Track,
                StartDate = race.StartDate,
                EndDate = race.EndDate,
                AddressId = race.AddressId,
                RaceCategory = race.RaceCategory,
                RaceType = race.RaceType,
                TrackDescription = race.TrackDescription,
                NewLayout = race.TrackLayout,
                Address = race.Address,
            };
            return View(raceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Failed to edit race!");
                return View("Edit", raceVM);
            }

            Race race = await raceService.ReadRaceByIdNoTracking(id);

            if(race != null)
            {

                try
                {
                    await photoService.DeletePhoto(race.TrackLayout);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete track layout!");
                    return View(raceVM);
                }
                var photoResult = await photoService.AddPhoto(raceVM.TrackLayout);

                Race newRace = new Race
                {
                    Id = id,
                    Name = raceVM.Name,
                    Track = raceVM.Track,
                    TrackDescription = raceVM.TrackDescription,
                    TrackLayout = photoResult.Url.ToString(),
                    StartDate = raceVM.StartDate,
                    EndDate = raceVM.EndDate,
                    RaceType = raceVM.RaceType,
                    RaceCategory = raceVM.RaceCategory,
                    AddressId = raceVM.AddressId,
                    Address = raceVM.Address,
                };

                raceService.Update(newRace);

                return RedirectToAction("Index");
            }
            else
            {
                return View(raceVM);
            }
        }

    }
}
