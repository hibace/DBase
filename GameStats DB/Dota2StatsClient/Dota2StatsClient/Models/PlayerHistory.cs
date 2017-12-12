using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class PlayerHistory 
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public DateTime Date { get; set; }
        public string GameMode { get; set; }
        public string Duration { get; set; }
        public string Nickname { get; set; }
        public int HeroId { get; set; }
        public string Hero { get; set; }
    }
}