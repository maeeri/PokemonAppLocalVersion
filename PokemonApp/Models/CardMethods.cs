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

        //find cards by rarity(Amazing Rare/Classic Collection/Common/LEGEND/Promo/Radiant Rare/Rare/Rare ACE/
        //Rare BREAK/Rare Holo/Rare Holo EX/Rare Holo GX/Rare Holo LV.X/Rare Holo Star/Rare Holo V/Rare Holo VMAX/,
        //Rare Holo VSTAR/Rare Prime/Rare Prism Star/Rare Rainbow/Rare Secret/Rare Shining/Rare Shiny/Rare Shiny GX/Rare Ultra/Uncommon/V/VM)
        public static List<Datum> GetCardsByRarity(string rarity)
        {
            var card = GetPokemonCards();
            var theseCards2 = card.Where(x => x.rarity != null).ToList();
            var valivaihe = theseCards2.Where(x => x.rarity.Equals(rarity, StringComparison.OrdinalIgnoreCase));
            var theseCards = valivaihe.ToList();
            return theseCards;
        }

        public static List<Datum> GetCardsByName(string searchString)
        {
            var allCards = GetPokemonCards();
            var theseCards = allCards.Where(x => x.name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            return theseCards;
        }
    }
}
