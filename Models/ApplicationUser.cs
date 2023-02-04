using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "full name")]
        public string FullName { get; set; }

    }
}
