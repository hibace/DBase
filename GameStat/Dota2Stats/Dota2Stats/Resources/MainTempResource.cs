using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class MainTempResource
    {
        public int Id { get; set; }

        public int IdPlayer { get; set; }
        public PlayerResource Player { get; set; }

        public int IdHero { get; set; }
        public HeroResource Hero { get; set; }

        public int IdMatch { get; set; }
        public MatchResource Match { get; set; }

        public MainTempResource() { }

        public MainTempResource(MainTemp model)
        {
            Id = model.Id;
            IdPlayer = model.Player.Id;
            IdHero = model.Hero.Id;
            IdMatch = model.Match.Id;
        }

        public MainTempResource Expand(MainTemp model)
        {
            Player = new PlayerResource();
            Hero = new HeroResource();
            Match = new MatchResource();

            Id = model.Id;

            Player.Id = model.Player.Id;
            IdPlayer = model.Player.Id;

            Hero.Id = model.Hero.Id;
            IdHero = model.Hero.Id;

            Match.Id = model.Match.Id;
            IdMatch = model.Match.Id;
            return this;
        }

        public MainTemp ToModel()
        {
            return new MainTemp
            {
                Id = Id,
                Player = new Player
                {
                    Id = IdPlayer
                },
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