using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net.Http.Headers;
namespace clas
{
    public class BadgeUrls
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }
    }

    public class Clan
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("clanLevel")]
        public int ClanLevel { get; set; }

        [JsonProperty("badgeUrls")]
        public BadgeUrls BadgeUrls { get; set; }
    }

    public class IconUrls
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("tiny")]
        public string Tiny { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }
    }

    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iconUrls")]
        public IconUrls IconUrls { get; set; }
    }

    public class Achievement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("target")]
        public int Target { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("completionInfo")]
        public string CompletionInfo { get; set; }

        [JsonProperty("village")]
        public string Village { get; set; }
    }

    public class Troop
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonProperty("village")]
        public string Village { get; set; }
    }

    public class Hero
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonProperty("village")]
        public string Village { get; set; }
    }

    public class Spell
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("maxLevel")]
        public int MaxLevel { get; set; }

        [JsonProperty("village")]
        public string Village { get; set; }
    }

    public class Root
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("townHallLevel")]
        public int TownHallLevel { get; set; }

        [JsonProperty("expLevel")]
        public int ExpLevel { get; set; }

        [JsonProperty("trophies")]
        public int Trophies { get; set; }

        [JsonProperty("bestTrophies")]
        public int BestTrophies { get; set; }

        [JsonProperty("warStars")]
        public int WarStars { get; set; }

        [JsonProperty("attackWins")]
        public int AttackWins { get; set; }

        [JsonProperty("defenseWins")]
        public int DefenseWins { get; set; }

        [JsonProperty("builderHallLevel")]
        public int BuilderHallLevel { get; set; }

        [JsonProperty("versusTrophies")]
        public int VersusTrophies { get; set; }

        [JsonProperty("bestVersusTrophies")]
        public int BestVersusTrophies { get; set; }

        [JsonProperty("versusBattleWins")]
        public int VersusBattleWins { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("warPreference")]
        public string WarPreference { get; set; }

        [JsonProperty("donations")]
        public int Donations { get; set; }

        [JsonProperty("donationsReceived")]
        public int DonationsReceived { get; set; }

        [JsonProperty("clan")]
        public Clan Clan { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("achievements")]
        public List<Achievement> Achievements { get; set; }

        [JsonProperty("versusBattleWinCount")]
        public int VersusBattleWinCount { get; set; }

        [JsonProperty("labels")]
        public List<object> Labels { get; set; }

        [JsonProperty("troops")]
        public List<Troop> Troops { get; set; }

        [JsonProperty("heroes")]
        public List<Hero> Heroes { get; set; }

        [JsonProperty("spells")]
        public List<Spell> Spells { get; set; }
    }

    public class CapitalLeague
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ChatLanguage
    {
        public int id { get; set; }
        public string name { get; set; }
        public string languageCode { get; set; }
    }

    public class Cursors
    {
    }

    public class Item
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool isFamilyFriendly { get; set; }
        public BadgeUrls badgeUrls { get; set; }
        public int clanLevel { get; set; }
        public int clanPoints { get; set; }
        public int clanVersusPoints { get; set; }
        public int clanCapitalPoints { get; set; }
        public CapitalLeague capitalLeague { get; set; }
        public int requiredTrophies { get; set; }
        public string warFrequency { get; set; }
        public int warWinStreak { get; set; }
        public int warWins { get; set; }
        public int warTies { get; set; }
        public int warLosses { get; set; }
        public bool isWarLogPublic { get; set; }
        public WarLeague warLeague { get; set; }
        public int members { get; set; }
        public List<Label> labels { get; set; }
        public int requiredVersusTrophies { get; set; }
        public int requiredTownhallLevel { get; set; }
        public Location location { get; set; }
        public ChatLanguage chatLanguage { get; set; }
    }

    public class Label
    {
        public int id { get; set; }
        public string name { get; set; }
        public IconUrls iconUrls { get; set; }
    }

    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isCountry { get; set; }
        public string countryCode { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class WarLeague
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    class PhotoClan
    {
        public Item[] items { get; set; }
    }
}
