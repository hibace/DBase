using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class MatchAndPlayers
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string GameMode { get; set; }
        public List<PlayersInMatch> PlayersInMatch { get; set; }
    }
}