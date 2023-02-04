using System.ComponentModel.DataAnnotations;

namespace E_ticket.Data.ViewModel
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password donot match")]
        [Display(Name = "Confirm password")]
        public string ConfrimPassword { get; set; }
    }
}
