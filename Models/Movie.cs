using E_ticket.Data;
using E_ticket.Data.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class Movie :IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        public string  Description { get; set; }

        public double Price { get; set; }
        
        [Display(Name="Movie Image")]
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        public int CinemaId { get; set; }

        public Cinema cinema { get; set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        public Collection<MovieActor> movieActors { get; set; }
    }
}
