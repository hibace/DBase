using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class PlayerStat : Base
    {
        public virtual Player Player { get; set; }
        public virtual bool Verified { get; set; }
        public virtual int TimeSpentPlaying { get; set; }
        public virtual int MostMatchesPlayed { get; set; }
    }
}