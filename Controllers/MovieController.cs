using E_ticket.Data;
using E_ticket.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    }
}
