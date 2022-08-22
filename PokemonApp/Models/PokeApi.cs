using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using APIHelpers;
using Microsoft.AspNetCore.Mvc;
using PokemonTcgSdk;

namespace PokemonApp.Models
{
    public class PokeApi
    {
        //const string url = "https://api.pokemontcg.io/v2/";

        //public static async Task<PokemonCard> GetSingleCard(string cardId)
        //{
        //    string urlParams = "cards/" + cardId;

        //    PokemonCard response = await ApiHelper.RunAsync<PokemonCard>(url, urlParams);

        //    return response;
        //}

        //public static async Task<List<PokemonCard>> GetAllCards()
        //{
        //    string urlParams = "cards/";
        //    var response = await ApiHelper.RunAsync<List<PokemonCard>>(url, urlParams);
        //    return response;
        //}
    }
}
