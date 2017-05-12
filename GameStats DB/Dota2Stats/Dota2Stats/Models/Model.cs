using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public abstract class Base
    {
        public virtual int Id { get; set; }
    }

    public class Hero : Base
    {
        public virtual string Name { get; set; }
        public virtual string HeroClass { get; set; }
        public virtual string Role { get; set; }
    }

    public class HeroStat : Base
    {
        public virtual int HeroDamage { get; set; }
        public virtual int HeroHealing { get; set; }
        public virtual int TowerDamage { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual Match Match { get; set; }
    }
    
    public class Item : Base
    {
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }

    public class ItemStat : Base
    {
        public virtual Item Item { get; set; }
        public virtual int TimeUsed { get; set; }
    }

    public class ItemTemp : Base
    {
        public virtual MainTemp MainTemp { get; set; }
        public virtual Item Item { get; set; }
    }

    public class MainTemp : Base
    {
        public virtual Player Player { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual Match Match { get; set; }
    }

    public class Match : Base
    {
        public virtual int Duration { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string GameMode { get; set; }
    }

    public class Player : Base
    {
        public virtual string Nickname { get; set; }
        public virtual int NumberOfGames { get; set; }
    }

    public class PlayerStat : Base
    {
        public virtual Player Player { get; set; }
        public virtual bool Verified { get; set; }
        public virtual int TimeSpentPlaying { get; set; }
        public virtual int MostMatchesPlayed { get; set; }
    }
}