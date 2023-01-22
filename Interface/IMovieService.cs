using E_ticket.Data.Base;
using E_ticket.Data.ViewModel;
using E_ticket.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_ticket.Interface
{
    public interface IMovieService: IEntityBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllAsyncInclude();

        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropDownVM> getDropDownMovie();

        Task addNewMovie(NewMovieVM newMovie);

        Task updateMovie(NewMovieVM updatedMocvie);

        Task<List<Movie>> GetMovieBySearch(string searchString);

    }
    
}
