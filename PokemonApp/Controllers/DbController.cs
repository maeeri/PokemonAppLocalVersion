using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //finds user by username
        public static User GetUser(string username)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        //saves cards to database
        public IActionResult DbSave(ViewModel viewModel)
        {
            viewModel.User = GetUser(User.Identity.Name);
            foreach (var card in viewModel.PCards)
            {
                card.User = viewModel.User.Id;
            }
            _context.PokemonCards.AddRange(viewModel.PCards);
            _context.SaveChanges();

            return RedirectToAction("Marketplace", "Home", viewModel);
        }

        //public IActionResult SearchFriend(string searchString)
        //{
        //    var viewModel = new ViewModel();
        //    viewModel.User = GetUser(User.Identity.Name);
        //    viewModel.Users =
        //        _context.Users.Where(x => x.Username.ToLower() == searchString.ToLower()).ToList();
        //    return RedirectToAction("Profile", "Home", viewModel);
        //} 

        public static List<User> SearchFriend(string searchString)
        {
            var userQ = _context.Users.Where(x => x.Username.ToLower().Contains(searchString.ToLower()));
            var userList = userQ.ToList();
            return userList;
        }
    }

}
