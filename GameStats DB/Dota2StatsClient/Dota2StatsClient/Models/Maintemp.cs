using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class Maintemp : Base
    {
        public int IdPLayer { get; set; }
        public int IdHero { get; set; }
        public int IdMatch { get; set; }
    }
}