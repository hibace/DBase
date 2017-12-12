using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsClient.Models
{
    public class Match : Base
    {
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public string GameMode { get; set; }
    }
}