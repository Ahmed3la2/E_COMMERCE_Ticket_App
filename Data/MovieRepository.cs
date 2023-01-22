using E_ticket.Data.Base;
using E_ticket.Data.ViewModel;
using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Data
{
    public class MovieRepository: EntityRepository<Movie> ,IMovieService
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task addNewMovie(NewMovieVM newMovie)
        {
            Movie MovieToAdd = new Movie
            {
                CinemaId = newMovie.CinemaId,
                Description = newMovie.Description,
                StartDate = newMovie.StartDate,
                EndDate  = newMovie.EndDate,
                ImageURL = newMovie.ImageURL,
                MovieCategory = newMovie.MovieCategory,
                Name  = newMovie.Name,
                Price = newMovie.Price,
                ProducerId = newMovie.ProducerId,
            };
           await _context.movies.AddAsync(MovieToAdd);
           await _context.SaveChangesAsync();
            
           foreach(var actorId in newMovie.ActorsIds)
           {
                _context.movieActors.Add(new MovieActor
                {
                    MovieId = MovieToAdd.Id,
                    ActorId = actorId
                });
           }
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllAsyncInclude()
        {
            return await _context.movies.Include(c => c.cinema).ToListAsync();
        }

        public async Task<NewMovieDropDownVM> getDropDownMovie()
        {
            var resonse = new NewMovieDropDownVM();

            resonse.Actors =    await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            resonse.producers = await   _context.producers.OrderBy(n => n.FullName).ToListAsync();
            resonse.cinemas =   await  _context.cinemas.OrderBy(n => n.Name).ToListAsync();

            return resonse;
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
           return _context.movies.Include(c => c.cinema).Include(p => p.Producer).Include(mp => mp.movieActors).ThenInclude(a => a.Actor).FirstOrDefaultAsync(i => i.Id == id);
        }

        public  Task<List<Movie>> GetMovieBySearch(string searchString)
        {
            var movies =  _context.movies.Include(p => p.Producer).Include(c => c.cinema).Include(am => am.movieActors).ThenInclude(a => a.Actor).Where(movie => movie.Name.Contains(searchString) || movie.Description.Contains(searchString)).ToListAsync();
            return movies;
        }

        public async Task updateMovie(NewMovieVM newMovie)
        {
           var movie = await GetMovieByIdAsync(newMovie.Id);
           if(newMovie != null)
            {
                movie.CinemaId = newMovie.CinemaId;
                movie.Description = newMovie.Description;
                movie.StartDate = newMovie.StartDate;
                movie.EndDate = newMovie.EndDate;
                movie.ImageURL = newMovie.ImageURL;
                movie.MovieCategory = newMovie.MovieCategory;
                movie.Name = newMovie.Name;
                movie.Price = newMovie.Price;
                movie.ProducerId = newMovie.ProducerId;
                await _context.SaveChangesAsync();
            }

            var actorMovie = _context.movieActors.Where(mId => mId.MovieId == newMovie.Id);
            _context.movieActors.RemoveRange(actorMovie);

            foreach (var ActorId in newMovie.ActorsIds)
            {
                _context.movieActors.Add(new MovieActor
                {
                    ActorId = ActorId,
                    MovieId = newMovie.Id
                });
            }

            await _context.SaveChangesAsync();
           
        }
    }
}
