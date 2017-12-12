using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Item : Base
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }
}