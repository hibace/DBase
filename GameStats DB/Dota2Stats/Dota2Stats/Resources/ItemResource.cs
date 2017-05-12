using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class ItemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ItemResource() { }

        public ItemResource(Item model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
        }

        public Item ToModel()
        {
            return new Item
            {
                Id = Id,
                Name = Name,
                Type = Type
            };
        }
    }
}