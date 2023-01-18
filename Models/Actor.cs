using E_ticket.Data.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="profile picture")]
        [Required]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "full name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage ="full name must between 2 and 50")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "biography")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Biography must between 6 and 50")]
        [Required]
        public string Bio { get; set; }

        public Collection<MovieActor> MovieActors { get; set; }
    }
}
