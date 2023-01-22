using E_ticket.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string  Description { get; set; }

        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "price in $")]
        public double Price { get; set; }
        
        [Display(Name="Movie Image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie start in")]
        [Required(ErrorMessage = "movie start in  is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end in")]
        [Required(ErrorMessage = "movie end is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "select category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "select cinema(s)")]
        [Required(ErrorMessage = "cinema(s) is required")]
        public int CinemaId { get; set; }

        [Display(Name = "select Producer(s)")]
        [Required(ErrorMessage = "Producer(s) is required")]
        public int ProducerId { get; set; }

        [Display(Name = "select Actor(s)")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public List<int> ActorsIds { get; set; }

       
    }
}
