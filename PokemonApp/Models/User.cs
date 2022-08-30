using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonApp.Models
{
    public partial class User
    {
        public User()
        {
            ConnectionOtherUserNavigations = new HashSet<Connection>();
            ConnectionUserNavigations = new HashSet<Connection>();
            Highscores = new HashSet<Highscore>();
            PokemonCards = new HashSet<PokemonCard>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int? Xp { get; set; }
        public int? Cash { get; set; }
        public DateTime? Freeclick { get; set; }

        public virtual ICollection<Connection> ConnectionOtherUserNavigations { get; set; }
        public virtual ICollection<Connection> ConnectionUserNavigations { get; set; }
        public virtual ICollection<Highscore> Highscores { get; set; }
        public virtual ICollection<PokemonCard> PokemonCards { get; set; }
    }
}
