using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokemonApp.Models;

namespace PokemonApp.Data
{
    public class PokemonAppContext : DbContext
    {
        public PokemonAppContext (DbContextOptions<PokemonAppContext> options)
            : base(options)
        {
        }

        public PokemonAppContext() { }

        public DbSet<PokemonApp.Models.User> User { get; set; }

        public DbSet<PokemonApp.Models.PokemonCard> PokemonCard { get; set; }

        public DbSet<PokemonApp.Models.Connection> Connection { get; set; }

        public DbSet<PokemonApp.Models.Highscore> Highscore { get; set; }
    }
}
