using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data.Entity;

namespace Dota2Stats.Models
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string hero_class  { get; set; }
        public string role { get; set; }
    }
}