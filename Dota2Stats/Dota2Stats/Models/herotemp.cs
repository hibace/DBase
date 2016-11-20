using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data.Entity;

namespace Dota2Stats.Models
{
    public class Herotemp
    {
        public int id { get; set; }
        public int id_maintemp { get; set; }
        public int id_hero { get; set; }
    }
}