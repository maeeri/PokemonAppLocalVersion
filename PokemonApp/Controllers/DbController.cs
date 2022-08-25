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
        private readonly PokemonDBContext _context = new PokemonDBContext();

        public IActionResult SaveUser()
        {
            User uusi = new User();
            uusi.Username = "testi32";
            uusi.Cash = 0;
            uusi.Xp = 0;

            _context.Add(uusi);
            _context.SaveChanges();

            return RedirectToAction(controllerName:"Home", actionName:"Index");
        }
    }
}
