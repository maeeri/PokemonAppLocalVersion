using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIHelpers;

namespace PokemonApp.Models
{
    public class PokeApi
    {
        const string url = "https://api.pokemontcg.io/v2/";

        public static async Task<PokemonCard> GetSingleCard(string cardId)
        {
            string urlParams = "cards/" + cardId;

            PokemonCard response = await ApiHelper.RunAsync<PokemonCard>(url, urlParams);

            return response;
        }
        public static async Task<PokemonCard> GetRandomCard(string nationalPokedexNumbers)
        {
            string urlParams = "cards/?nationalPokedexNumbers:";
            PokemonCard response = await ApiHelper.RunAsync<PokemonCard>(url, urlParams);
            return response;
        }
    }
}
