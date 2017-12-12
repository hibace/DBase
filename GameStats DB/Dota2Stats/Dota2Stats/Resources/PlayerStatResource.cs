using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class PlayerStatResource
    {
        public int Id { get; set; }
        public int IdPlayer { get; set; }
        public PlayerResource Player { get; set; }
        public bool Verified { get; set; }
        public int TimeSpentPlaying { get; set; }
        public int MostMatchesPlayed { get; set; }

        public PlayerStatResource() { }

        public PlayerStatResource(PlayerStat model)
        {
            Id = model.Id;
            Verified = model.Verified;
            TimeSpentPlaying = model.TimeSpentPlaying;
            MostMatchesPlayed = model.MostMatchesPlayed;
            IdPlayer = model.Player.Id;
        }

        public PlayerStatResource Expand(PlayerStat model)
        {
            Player = new PlayerResource();

            Id = model.Id;
            Verified = model.Verified;
            TimeSpentPlaying = model.TimeSpentPlaying;
            MostMatchesPlayed = model.MostMatchesPlayed;

            Player.Id = model.Player.Id;
            IdPlayer = model.Player.Id;
            
            return this;
        }

        public PlayerStat ToModel()
        {
            return new PlayerStat
            {
                Id = Id,
                Verified = Verified,
                TimeSpentPlaying = TimeSpentPlaying,
                MostMatchesPlayed = MostMatchesPlayed,

                Player = new Player
                {
                    Id = IdPlayer
                }
            };
        }
    }
}