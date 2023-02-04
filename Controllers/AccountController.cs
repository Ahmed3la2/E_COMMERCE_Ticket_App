using E_ticket.Data;
using E_ticket.Data.Static;
using E_ticket.Data.ViewModel;
using E_ticket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_ticket.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var User = await _userManager.FindByEmailAsync(loginVM.Email);

            if (User != null)
            {
                var PasswordCheck = await _userManager.CheckPasswordAsync(User, loginVM.Password);
                if (PasswordCheck)
                {
                    var res = await _signInManager.PasswordSignInAsync(User, loginVM.Password, false, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                }
            }
            TempData["error"] = "Wrong Credintial";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            var User = await _userManager.FindByEmailAsync(registerVM.Email);
            if (User != null)
            {
                TempData["error"] = "Email adrress is Used";
                return View(registerVM);
            }

            var NewUser = new ApplicationUser
            {
                Email = registerVM.Email,
                FullName = registerVM.FullName,
                UserName = registerVM.Email
            };

            var createUserRes = await _userManager.CreateAsync(NewUser, registerVM.Password);
            if (createUserRes.Succeeded)
            {
                await _userManager.AddToRoleAsync(NewUser, UsersRoles.User);
            }

            return View("RegsiterComplete");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movie");
        } 
    }
}
