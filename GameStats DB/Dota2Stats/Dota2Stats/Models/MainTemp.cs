using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public class MainTemp : Base
    {
        public virtual Player Player { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual Match Match { get; set; }
    }
}