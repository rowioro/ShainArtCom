using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShainArtCom.ViewModels;
using System.Threading.Tasks;

namespace ShainArtCom.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(loginVM.UserName);

                if (loginVM.UserName == "rowioro" && loginVM.Password == "Robert260471*")
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Arts");
                    }
                }

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "wrong password or user");

            return View(loginVM);
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                if (registerVM.Email == registerVM.ConfirmEmail)
                {
                    var user = new IdentityUser() { UserName = registerVM.UserName, Email = registerVM.Email};
                    var result = await _userManager.CreateAsync(user, registerVM.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Form requires password with 8 signs (digit-, uppercase-, lowercase-, special charakter) and confirmed email");

            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
