using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class ItemStat : Base
    {
        public virtual Item Item { get; set; }
        public virtual int TimeUsed { get; set; }
    }
}