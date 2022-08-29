﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace PokemonApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous] //näyttää myös rekisteröitymättömälle käyttäjälle tämän osion
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Marketplace(ViewModel viewModel)
        {
            //ViewModel viewModel = new ViewModel();
            viewModel.User = DbController.GetUser(User.Identity.Name);
            viewModel.PCards = new List<PokemonCard>();
            return View(viewModel);
            
        }

        [AllowAnonymous]
        public IActionResult CardTest()
        {
            return View();

        }
        [AllowAnonymous]
        public IActionResult Profile(ViewModel viewModel)
        {
            if (viewModel.Users == null)
            {
                var viewModelEmpty = new ViewModel();
                viewModelEmpty.User = DbController.GetUser(User.Identity.Name);
                return View(viewModelEmpty);
            }
            return View(viewModel);
        }

        [Authorize]
        public IActionResult Claims()
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
