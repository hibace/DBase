using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Match : Base
    {
        public virtual int Duration { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string GameMode { get; set; }
    }
}