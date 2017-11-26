using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class HeroStatResource
    {
        public int Id { get; set; }
        public int HeroDamage { get; set; }
        public int HeroHealing { get; set; }
        public int TowerDamage { get; set; }

        public int IdHero { get; set; }
        public HeroResource Hero { get; set; }

        public int IdMatch { get; set; }
        public MatchResource Match { get; set; }

        public HeroStatResource() { }

        public HeroStatResource(HeroStat model)
        {
            Id = model.Id;
            HeroDamage = model.HeroDamage;
            HeroHealing = model.HeroHealing;
            TowerDamage = model.TowerDamage;
            IdHero = model.Hero.Id;
            IdMatch = model.Match.Id;
        }

        public HeroStatResource Expand(HeroStat model)
        {
            Hero = new HeroResource();
            Match = new MatchResource();

            Id = model.Id;
            HeroDamage = model.HeroDamage;
            HeroHealing = model.HeroHealing;
            TowerDamage = model.TowerDamage;

            Hero.Id = model.Hero.Id;
            IdHero = model.Hero.Id;

            Match.Id = model.Match.Id;
            IdMatch = model.Match.Id;
            return this;
        }

        public HeroStat ToModel()
        {
            return new HeroStat
            {
                Id = Id,
                HeroDamage = HeroDamage,
                HeroHealing = HeroHealing,
                TowerDamage = TowerDamage,

                Hero = new Hero
                {
                    Id = IdHero
                },
                Match = new Match
                {
                    Id = IdMatch
                }
            };
        }
    }
}