using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class MatchResource
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public string GameMode { get; set; }

        public MatchResource() { }

        public MatchResource(Match model)
        {
            Id = model.Id;
            Duration = model.Duration;
            Date = model.Date;
            GameMode = model.GameMode;
        }

        public Match ToModel()
        {
            return new Match
            {
                Id = Id,
                Duration = Duration,
                Date = Date,
                GameMode = GameMode
            };
        }
    }
}