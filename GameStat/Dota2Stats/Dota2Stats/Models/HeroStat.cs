using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class HeroStat : Base
    {
        public virtual int HeroDamage { get; set; }
        public virtual int HeroHealing { get; set; }
        public virtual int TowerDamage { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual Match Match { get; set; }
    }
}