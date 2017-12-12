using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class Player : Base
    {
        public string Nickname { get; set; }
        public int NumberOfGames { get; set; }
    }
}