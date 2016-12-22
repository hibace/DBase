using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Dota2Stats.Models
{
    public class Hero_stat
    {
        public int id { get; set; }
        public int id_hero { get; set; }
        public int hero_damage { get; set; }
        public int hero_healing { get; set; }
        public int tower_damage { get; set; }
        public int id_match { get; set;  }
    }
}