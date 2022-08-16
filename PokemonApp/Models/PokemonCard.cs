namespace PokemonApp.Models
{
    public class PokemonCard
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string supertype { get; set; }
        public string[] subtypes { get; set; }
        public string level { get; set; }
        public string hp { get; set; }
        public string[] types { get; set; }
        public string evolvesFrom { get; set; }
        public Ability[] abilities { get; set; }
        public Attack[] attacks { get; set; }
        public Weakness[] weaknesses { get; set; }
        public Resistance[] resistances { get; set; }
        public string[] retreatCost { get; set; }
        public int convertedRetreatCost { get; set; }
        public Set set { get; set; }
        public string number { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public int[] nationalPokedexNumbers { get; set; }
        public Legalities1 legalities { get; set; }
        public Images1 images { get; set; }
        public Tcgplayer tcgplayer { get; set; }
        public Cardmarket cardmarket { get; set; }
    }

    public class Set
    {
        public string id { get; set; }
        public string name { get; set; }
        public string series { get; set; }
        public int printedTotal { get; set; }
        public int total { get; set; }
        public Legalities legalities { get; set; }
        public string ptcgoCode { get; set; }
        public string releaseDate { get; set; }
        public string updatedAt { get; set; }
        public Images images { get; set; }
    }

    public class Legalities
    {
        public string unlimited { get; set; }
    }

    public class Images
    {
        public string symbol { get; set; }
        public string logo { get; set; }
    }

    public class Legalities1
    {
        public string unlimited { get; set; }
    }

    public class Images1
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class Tcgplayer
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices prices { get; set; }
    }

    public class Prices
    {
        public Holofoil holofoil { get; set; }
        public Reverseholofoil reverseHolofoil { get; set; }
    }

    public class Holofoil
    {
        public float low { get; set; }
        public float mid { get; set; }
        public float high { get; set; }
        public float market { get; set; }
        public float directLow { get; set; }
    }

    public class Reverseholofoil
    {
        public float low { get; set; }
        public float mid { get; set; }
        public float high { get; set; }
        public float market { get; set; }
    }

    public class Cardmarket
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices1 prices { get; set; }
    }

    public class Prices1
    {
        public float averageSellPrice { get; set; }
        public float lowPrice { get; set; }
        public float trendPrice { get; set; }
        public float reverseHoloSell { get; set; }
        public float reverseHoloLow { get; set; }
        public float reverseHoloTrend { get; set; }
        public float lowPriceExPlus { get; set; }
        public float avg1 { get; set; }
        public float avg7 { get; set; }
        public float avg30 { get; set; }
        public float reverseHoloAvg1 { get; set; }
        public float reverseHoloAvg7 { get; set; }
        public float reverseHoloAvg30 { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Attack
    {
        public string name { get; set; }
        public string[] cost { get; set; }
        public int convertedEnergyCost { get; set; }
        public string damage { get; set; }
        public string text { get; set; }
    }

    public class Weakness
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Resistance
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}