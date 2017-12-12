using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Hero : Base
    {
        public virtual string Name { get; set; }
        public virtual string HeroClass { get; set; }
        public virtual string Role { get; set; }
    }
}