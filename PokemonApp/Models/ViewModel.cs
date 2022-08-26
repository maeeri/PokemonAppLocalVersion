using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    [NotMapped]
    public class ViewModel
    {
        public User User { get; set; }
        public Connection Connection { get; set; }
        public Highscore Highscore { get; set; }
        public PokemonCard PokemonCard { get; set; }
        public List<User> Users { get; set; }
        public List<Connection> Connections { get; set; }
        public List<Highscore> Highscores { get; set; }
        public List<PokemonCard> PCards { get; set; }
    }
}
