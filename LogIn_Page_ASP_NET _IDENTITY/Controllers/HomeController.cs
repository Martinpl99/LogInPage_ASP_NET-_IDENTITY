﻿using IDENTITY_Cwiczenia.Identity.Model;
using IDENTITY_Cwiczenia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IDENTITY_Cwiczenia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userMgr)
        {
            userManager= userMgr;
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user= await userManager.GetUserAsync(HttpContext.User);
            string message="Hello"+user.UserName;
            return View((object)message);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}