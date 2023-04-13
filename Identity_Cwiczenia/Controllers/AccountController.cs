using IDENTITY_Cwiczenia.Identity.Model;
using IDENTITY_Cwiczenia.Identity.Model.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IDENTITY_Cwiczenia.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> usr_manager,SignInManager<User> sign_manager) 
        {
            userManager = usr_manager;
            signInManager = sign_manager;
        }

        [AllowAnonymous]
        public IActionResult Log_in(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Log_in(Login login)
        {
            if(ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(login.Email);
                if(user!=null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(user, login.Password, login.Remember, false);
                    if(result.Succeeded)
                    {
                        return Redirect(login.ReturnUrl ?? "/");
                    }
                    ModelState.AddModelError(nameof(login.Email), "Login failed: Invalid Email or password");
                }
            }
            return View(login);
        }

        public async Task<IActionResult> Log_out()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
