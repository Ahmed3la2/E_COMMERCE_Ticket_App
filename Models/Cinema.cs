using E_ticket.Data.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Name")]
        public string  Name { get; set; }

        [Display(Name = "Cinema logo")]
        public string Logo { get; set; }

        [Display(Name = "Cinema Description")]
        public string  Description { get; set; }

        public Collection<Movie> Movies { get; set; }
    }
}
