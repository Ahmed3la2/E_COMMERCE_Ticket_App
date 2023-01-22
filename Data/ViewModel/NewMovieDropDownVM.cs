using E_ticket.Models;
using System.Collections.Generic;

namespace E_ticket.Data.ViewModel
{
    public class NewMovieDropDownVM
    {
        public List<Actor> Actors { get; set; }
        public List<Producer> producers { get; set; }
        public List<Cinema> cinemas { get; set; }
    }
}
