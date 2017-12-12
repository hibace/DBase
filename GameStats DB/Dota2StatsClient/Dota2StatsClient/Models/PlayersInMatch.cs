using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class PlayersInMatch 
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public string Nickname { get; set; }
    }
}