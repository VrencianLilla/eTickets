using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly AppDbContext _appDbContext;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
			_signInManager = signInManager;
			_appDbContext = appDbContext;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if(!ModelState.IsValid) return View(loginVM);

			var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
			if(user != null)
			{
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
				if(passwordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Movies");
					}
				}
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

			TempData["Error"] = "Wrong credentials (or User does not exists). Please, try again!";
			return View(loginVM);
		}


        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            else
            {
                TempData["Error"] = "The Password needs at least one upper case character, one lower case character, one special character and number!";
                return View(registerVM);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
