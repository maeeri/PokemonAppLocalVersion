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

        //find certain types of cards (Energy/Pokémon/Trainer), doesn't work yet,because limited number of cards
        //in json file
        public static List<Datum> FindCards(string supertype)
        {
            var allCards = GetPokemonCards();
            var theseCards = allCards.Where(x => x.supertype.Equals(supertype, StringComparison.OrdinalIgnoreCase)).ToList();
            return theseCards;
        }

        //find cards by rarity(Amazing Rare/Classic Collection/Common/LEGEND/Promo/Radiant Rare/Rare/Rare ACE/
        //Rare BREAK/Rare Holo/Rare Holo EX/Rare Holo GX/Rare Holo LV.X/Rare Holo Star/Rare Holo V/Rare Holo VMAX/,
        //Rare Holo VSTAR/Rare Prime/Rare Prism Star/Rare Rainbow/Rare Secret/Rare Shining/Rare Shiny/Rare Shiny GX/Rare Ultra/Uncommon/V/VM)
        //public static List<Datum> GetCardsByRarity(string rarity)
        //{
        //    var allCards = GetPokemonCards();
        //    var theseCardsIe = from card in allCards
        //        where card.rarity.Contains(rarity, StringComparison.OrdinalIgnoreCase)
        //        select card;
        //    var theseCards = theseCardsIe.ToList();
        //    return theseCards;
        //}

        //search cards by name
        public static List<Datum> GetCardsByName(string searchString)
        {
            var allCards = GetPokemonCards();
            var theseCards = allCards.Where(x => x.name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            return theseCards;
        }
    }
}
