using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
namespace E_ticket.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieRepo;

        public MovieController(IMovieService movieService )
        {
            _movieRepo = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var AllMovie = await _movieRepo.GetAllAsyncInclude();
            return View(AllMovie);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _movieRepo.GetMovieBySearch(searchString);
            return View("Index", movies);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var Movie = await _movieRepo.GetMovieByIdAsync(id);
            return View(Movie);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _movieRepo.getDropDownMovie();

            ViewBag.CinemaId = new SelectList(movieDropDownData.cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropDownData.producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropDownData.Actors , "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMovie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _movieRepo.getDropDownMovie();

                ViewBag.CinemaId = new SelectList(movieDropDownData.cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropDownData.producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                return View(newMovie);
            }
            await _movieRepo.addNewMovie(newMovie);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieRepo.GetMovieByIdAsync(id);

            var movieDropDownData = await _movieRepo.getDropDownMovie();

            NewMovieVM MovieVM = new NewMovieVM
            {
                Id = movie.Id,
                StartDate = movie.StartDate,
                CinemaId = movie.CinemaId,
                Description = movie.Description,
                EndDate = movie.EndDate,
                ImageURL = movie.ImageURL,
                Name = movie.Name,
                Price = movie.Price,
                ProducerId = movie.ProducerId,
                ActorsIds = movie.movieActors.Select(a => a.ActorId).ToList(),
                MovieCategory= movie.MovieCategory,
            };

            ViewBag.CinemaId = new SelectList(movieDropDownData.cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropDownData.producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View(MovieVM);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id,  NewMovieVM UpdatedMovie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _movieRepo.getDropDownMovie();

                ViewBag.CinemaId = new SelectList(movieDropDownData.cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropDownData.producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                return View(UpdatedMovie);
            }

            await _movieRepo.updateMovie(UpdatedMovie);
            return RedirectToAction(nameof(Index));
        }


    }
}
