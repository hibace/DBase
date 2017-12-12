using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class ItemStatResource
    {
        public int Id { get; set; }

        public int IdItem { get; set; }
        public ItemResource Item { get; set; }

        public int TimeUsed { get; set; }

        public ItemStatResource() { }

        public ItemStatResource(ItemStat model)
        {
            Id = model.Id;
            IdItem = model.Item.Id;
            TimeUsed = model.TimeUsed;
        }

        public ItemStatResource Expand(ItemStat model)
        {
            Item = new ItemResource();
           
            Id = model.Id;
            TimeUsed = model.TimeUsed;

            Item.Id = model.Item.Id;
            IdItem = model.Item.Id;
            
            return this;
        }

        public ItemStat ToModel()
        {
            return new ItemStat
            {
                Id = Id,

                Item = new Item
                {
                    Id = IdItem
                },
                TimeUsed = TimeUsed
            };
        }
    }
}