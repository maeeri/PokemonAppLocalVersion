using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonApp.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public int? Xp { get; set; }
        public int? Cash { get; set; }
        public DateTime? Freeclick { get; set; }
    }
}
