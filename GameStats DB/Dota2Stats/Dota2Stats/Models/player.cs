using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Player
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public string number_of_games { get; set; }
    }
}