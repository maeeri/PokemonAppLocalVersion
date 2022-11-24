using Microsoft.AspNetCore.Mvc;
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
using PokemonApp.Data;


namespace PokemonApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PokemonAppContext _context;

        public HomeController(ILogger<HomeController> logger, PokemonAppContext context)
        {
            _logger = logger;
            _context = context;
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
            //if (viewModel.User.Username == null)
            //{
                
            //}
            //else
            //{
            //    viewModel.User = DbController.GetUser("", _context);
            //}
            viewModel.User = _context.User.FirstOrDefault();
            viewModel.PCards = new List<PokemonCard>();

            return View(viewModel);

        }

        [AllowAnonymous]
        public IActionResult CardTest()
        {
            return View();

        }

        public IActionResult Profile(string searchString, ViewModel viewModel)
        {
            if (searchString == null)
            {
                var viewModelEmpty = new ViewModel();
                viewModelEmpty.User = _context.User.FirstOrDefault();
                viewModelEmpty.Connections = new List<Connection>();
                viewModelEmpty.PCards = _context.PokemonCard.Where(x => x.User == viewModelEmpty.User.Id).ToList();
                return View(viewModelEmpty);
            }
            viewModel.User = DbController.GetUser("mae", _context);
            viewModel.Connections = DbController.GetConnections(viewModel.User.Id, _context);
            viewModel.Users = DbController.SearchFriend(viewModel, searchString, _context);
            viewModel.PCards = _context.PokemonCard.Where(p => p.User == viewModel.User.Id).ToList();
            
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
