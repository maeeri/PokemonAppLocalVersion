using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIHelpers;
using PokemonApp.Models.Testi;

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

        public static async Task<PokemonCard2[]> GetCollection()
        {
            string urlParams = "cards";

            PokemonCard2[] response = await ApiHelper.RunAsync<PokemonCard2[]>(url, urlParams);

            return response;
        }
    }
}
