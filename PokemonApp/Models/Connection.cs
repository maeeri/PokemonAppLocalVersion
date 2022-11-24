using System;
using System.Collections.Generic;

#nullable disable

namespace PokemonApp.Models
{
    public class Connection
    {

        public int Id { get; set; }
        public int User { get; set; }
        public int OtherUser { get; set; }

        public virtual User OtherUserNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
