using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Text.Json;

namespace PokemonApp.Models
{
    public class CardMethods
    {
        //read data from json file containing all pokemon
        public static List<Datum> GetPokemonCards()
        {
            string json = File.ReadAllText("./wwwroot/js/pokemons.json");
            var pokemonCards = JsonSerializer.Deserialize<PokemonCards>(json);
            var separateCards = pokemonCards.data.ToList();

            return separateCards;
        }

    }
}
