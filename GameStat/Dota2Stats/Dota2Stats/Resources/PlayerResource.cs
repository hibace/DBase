using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class PlayerResource
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int NumberOfGames { get; set; }

        public PlayerResource() { }

        public PlayerResource(Player model)
        {
            Id = model.Id;
            Nickname = model.Nickname;
            NumberOfGames = model.NumberOfGames;
        }
        
        public Player ToModel()
        {
            return new Player
            {
                Id = Id,
                Nickname = Nickname,
                NumberOfGames = NumberOfGames
            };
        }
    }
}