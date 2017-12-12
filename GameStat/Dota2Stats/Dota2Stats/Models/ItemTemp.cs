using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class ItemTemp : Base
    {
        public virtual MainTemp MainTemp { get; set; }
        public virtual Item Item { get; set; }
    }
}