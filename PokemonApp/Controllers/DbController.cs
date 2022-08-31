using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using PokemonApp.Models;
using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;

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
                uusi.Xp = 0;
                uusi.Cash = 0;
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
            Response.Redirect("/Home/Profile");
        }

        //buy pack of cards
        public void BuyPack(ViewModel viewModel, int? pack)
        {
            switch (pack)
            {
                case 0:
                    AddXp(viewModel, 5);
                    break;
                case 1:
                    AddXp(viewModel, 10);
                    UseCash(viewModel, 10);
                    break;
                case 2:
                    AddXp(viewModel, 20);
                    UseCash(viewModel, 20);
                    break;
                case 3:
                    AddXp(viewModel, 30);
                    UseCash(viewModel, 30);
                    break;
                default:
                    return;
            }
        }

        //deletes all of user's pokemon cards. To be used for punishment (or testing, whatever is most convenient)
        public static void DeleteAllPcards(ViewModel viewModel)
        {
            viewModel.PCards = _context.PokemonCards.Where(x => x.User.Equals(viewModel.User.Id)).ToList();
            _context.PokemonCards.RemoveRange(viewModel.PCards);
            _context.SaveChanges();
        }

        //saves cards to database and updates timer for free pack
        public IActionResult DbSave(ViewModel viewModel, int? pack, int? amount)
        {
            viewModel.User = GetUser(User.Identity.Name);
            
            foreach (var card in viewModel.PCards)
            {
                card.User = viewModel.User.Id;
            }

            var viimeisin = viewModel.User.Freeclick.GetValueOrDefault();
            if (viimeisin.AddDays(1) < DateTime.Now || viimeisin == null)
            {
                viewModel.User.Freeclick = DateTime.Now;
                _context.Update(viewModel.User);

            }

            if (pack != null && viewModel.User.Cash >= amount)
            {
                BuyPack(viewModel, pack);
                _context.PokemonCards.AddRange(viewModel.PCards);
            }

            _context.SaveChanges();

            return RedirectToAction("Marketplace", "Home", viewModel);
        }

        //Add cash to user profile to be used in purchasing packs
        public void AddCash(ViewModel viewModel, int amount)
        {
            if (viewModel.User.Cash == null)
                viewModel.User.Cash = amount;
            else
                viewModel.User.Cash += amount;
            _context.Update(viewModel.User);
            _context.SaveChanges();

        }

        //Remove cash by treating yourself to a pack
        public void UseCash(ViewModel viewModel, int amount)
        {
            viewModel.User.Cash -= amount;
            _context.Update(viewModel.User);
            _context.SaveChanges();
        }

        public bool Countdown()
        {
            var user = GetUser(User.Identity.Name);
            var viimeisin = user.Freeclick.GetValueOrDefault();
            if (viimeisin.AddDays(1) < DateTime.Now || viimeisin == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Add XP to user
        public static void AddXp(ViewModel viewModel, int amount)
        {
            if (viewModel.User.Xp == 0)
                SaveXP(viewModel.User.Username, amount);
            else
                viewModel.User.Xp = viewModel.User.Xp + amount;
            _context.Update(viewModel.User);
            _context.SaveChanges();

        }

        //Finds a list of users and takes a search string as parameter
        public static List<User> SearchFriend(ViewModel viewModel, string searchString)
        {
            var userQ = _context.Users.Where(x => x.Username.ToLower().Contains(searchString.ToLower()));
            var userList = userQ.ToList();
            var otherList = new List<User>();
            foreach (var user in userList)
            {
                if(viewModel.Connections.Any(x => x.User == viewModel.User.Id && x.OtherUser == user.Id))
                    continue;
                otherList.Add(user);
            }
            return otherList;
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
            Response.Redirect("/Home/Profile");
        }

        public static void SaveXP(string username, int xp)
        {
            var user = _context.Users.Where(x => x.Username == username).Single();
            user.Cash = 100;
            user.Cash += xp;
            _context.Users.Update(user);
            _context.SaveChanges();

        }
        
    }

}
