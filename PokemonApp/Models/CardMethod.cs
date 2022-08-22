using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;

namespace PokemonApp.Models
{
    public class CardMethod
    {
        public static async Task<PokemonCard> GetByRarity(string rarity)
        {
            var list = Card.Get<Pokemon>();
            return list.Card;
        }
    }
}
