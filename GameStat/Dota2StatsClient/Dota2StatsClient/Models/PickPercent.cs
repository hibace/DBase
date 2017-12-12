using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class HeroPercent
    {
        public int PlayerId { get; set; }
        public string Nickname { get; set; }
        public int HeroId { get; set; }
        public string Hero { get; set; }
        public int PlayedGamesOnThisHero { get; set; }
        public double PickPercent { get; set; }
    }
}