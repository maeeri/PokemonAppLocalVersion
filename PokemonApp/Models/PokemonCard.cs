using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonApp.Models
{
    public partial class PokemonCard
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string Name { get; set; }
        public string PokemonId { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
