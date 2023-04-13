using IDENTITY_Cwiczenia.Identity.Model;
using IDENTITY_Cwiczenia.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace IDENTITY_Cwiczenia.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AdminController(UserManager<User> usrManager)
        {
            _userManager= usrManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create(UserData user)
        {
            if(ModelState.IsValid)
            {
                User _user = new User
                {
                    UserName = user.Name,
                    Email = user.Email,
                };

                IdentityResult result=await _userManager.CreateAsync(_user,user.Password);
                if(result.Succeeded) 
                {
                    return RedirectToAction("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                
            }

            return View(user);
        }
    }
}
