using E_ticket.Data;
using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaRepo;

        public CinemaController(ICinemaService cinemaRepository)
        {
            _cinemaRepo = cinemaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Actors = await _cinemaRepo.GetAsync();

            return View(Actors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("ProfilePictureURL,FullName,Bio")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _cinemaRepo.Add(cinema);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int id)
        {
            var ActorDeatail = await _cinemaRepo.GetByIdAsync(id);
            return View(ActorDeatail);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _cinemaRepo.GetByIdAsync(id);
            return View(actor);
        }
        [HttpPost]
        public IActionResult Edit(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _cinemaRepo.Update(cinema);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _cinemaRepo.DeleteByIds(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
