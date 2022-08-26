using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class DbController : Controller
    {
        private static readonly PokemonDBContext _context = new PokemonDBContext();

        public static void SaveUser(string username)
        {
            if (_context.Users.FirstOrDefault(x => x.Username == username) == null)
            {
                User uusi = new User();
                uusi.Username = username;

                _context.Add(uusi);
                _context.SaveChanges();
            }
            
        }

        public static User GetUser(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public IActionResult DbSave(ViewModel viewModel)
        {
            foreach (var card in viewModel.PCards)
            {
                card.User = viewModel.User.Id;
            }
            _context.PokemonCards.AddRange(viewModel.PCards);
            _context.SaveChanges();

            return RedirectToAction("Marketplace", "Home");
        }
    }

}
