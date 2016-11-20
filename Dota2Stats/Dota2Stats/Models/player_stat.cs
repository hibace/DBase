using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Player_stat
    {
        public int id { get; set; }
        public int id_player { get; set; }
        public bool verified { get; set; }
        public int time_spent_playing  { get; set; }
        public int most_matches_played  { get; set; }
    }
}