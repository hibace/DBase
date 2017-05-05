using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class HeroResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hero_class { get; set; }
        public string Role { get; set; }

        public HeroResource() { }

        public HeroResource(Hero model)
        {
            Id = model.Id;
            Name = model.Name;
            Hero_class = model.Hero_class;
            Role = model.Role;
        }

        public Hero ToModel()
        {
            return new Hero
            {
                Id = Id,
                Name = Name,
                Hero_class = Hero_class,
                Role = Role
            };
        }
    }
}