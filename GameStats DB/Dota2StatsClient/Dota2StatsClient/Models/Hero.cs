using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class Hero : Base
    {
        public string Name { get; set; }
        public string HeroClass { get; set; }
        public string Role { get; set; }
    }
}