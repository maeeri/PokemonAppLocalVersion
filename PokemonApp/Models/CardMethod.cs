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
        public static string GetName()
        {
            return SuperTypes.All().ToString();
        }
    }
}
