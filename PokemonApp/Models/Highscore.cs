using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonApp.Models
{
    public partial class Highscore
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int? Victories { get; set; }
        public int? Losses { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
