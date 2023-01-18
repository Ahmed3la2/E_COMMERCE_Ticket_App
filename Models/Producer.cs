using E_ticket.Data.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "ProfilePictureURL")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        public Collection<Movie> Moivies { get; set; }
    }
}
