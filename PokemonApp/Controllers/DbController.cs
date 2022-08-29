using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PokemonApp.Models;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

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

        //finds user by id
        public static User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        //gets friend connections
        public static List<Connection> GetConnections(int id)
        {
            var connections = _context.Connections.Where(x => x.User == id).ToList();
            return connections;
        }

        //removes a friend from user's follow list
        public void StopFollowing(int id)
        {
            var con = _context.Connections.FirstOrDefault(x => x.Id == id);
            _context.Connections.Remove(con);
            _context.SaveChanges();
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

        //Finds a list of users and takes a search string as parameter
        public static List<User> SearchFriend(string searchString)
        {
            var userQ = _context.Users.Where(x => x.Username.ToLower().Contains(searchString.ToLower()));
            var userList = userQ.ToList();
            return userList;
        }

        //User follows another user, if not already followed
        public void FollowFriend(int userId, int followId)
        {
            var viewModel = new ViewModel();
            viewModel.Connection = new Connection();
            viewModel.Connections = _context.Connections.Where(x => x.User == userId).ToList();
            var notFound = true;

            foreach (var connection in viewModel.Connections)
            {
                if (connection.OtherUser == followId)
                {
                    notFound = false;
                }
            }

            if (notFound)
            {
                viewModel.Connection.User = userId;
                viewModel.Connection.OtherUser = followId;
                _context.Add(viewModel.Connection);
                _context.SaveChanges();
            }
            
        }
    }

}
