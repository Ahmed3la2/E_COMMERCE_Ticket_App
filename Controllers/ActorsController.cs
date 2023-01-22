using E_ticket.Data;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public async Task<IActionResult> Index()
        {
            var Actors = await _actorsService.GetAsync();

            return View(Actors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _actorsService.Add(actor);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int id)
        {
            var ActorDeatail = await _actorsService.GetByIdAsync(id);
            return View(ActorDeatail);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);
            return View(actor);
        }


        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _actorsService.Update(actor);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _actorsService.DeleteByIds(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
