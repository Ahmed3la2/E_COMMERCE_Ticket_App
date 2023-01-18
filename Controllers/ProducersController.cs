using E_ticket.Data;
using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Controllers
{
    public class ProducersController : Controller
    {
       private readonly IProducerService _producerRepo;

        public ProducersController(IProducerService producerService )
        {
            _producerRepo = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var Actors = await _producerRepo.GetAsync();

            return View(Actors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _producerRepo.Add(producer);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Detail(int id)
        {
            var ActorDeatail = await _producerRepo.GetByIdAsync(id);
            return View(ActorDeatail);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _producerRepo.GetByIdAsync(id);
            return View(actor);
        }
        [HttpPost]
        public IActionResult Edit(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _producerRepo.Update(producer);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _producerRepo.DeleteByIds(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
