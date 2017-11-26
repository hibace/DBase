using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class Player : Base
    {
        public virtual string Nickname { get; set; }
        public virtual int NumberOfGames { get; set; }
    }
}