using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Match
    {
        public int id { get; set; }
        public int duration { get; set; }
        public string date { get; set; }
        public string game_mode { get; set; }
    }
}