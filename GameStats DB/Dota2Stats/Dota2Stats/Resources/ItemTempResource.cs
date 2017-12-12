using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dota2Stats.Models;

namespace Dota2Stats.Resources
{
    public class ItemTempResource
    {
        public int Id { get; set; }

        public int IdItem { get; set; }
        public ItemResource Item { get; set; }

        public int IdMainTemp { get; set; }
        public MainTempResource MainTemp { get; set; }

        public ItemTempResource() { }

        public ItemTempResource(ItemTemp model)
        {
            Id = model.Id;

            //Item.Id = model.Item.Id;
            IdItem = model.Item.Id;

            //MainTemp.Id = model.MainTemp.Id;
            IdMainTemp = model.MainTemp.Id;

        }

        public ItemTempResource Expand(ItemTemp model)
        {
            Item = new ItemResource();
            MainTemp = new MainTempResource();

            Id = model.Id;

            Item.Id = model.Item.Id;
            IdItem = model.Item.Id;

            MainTemp.Id = model.MainTemp.Id;
            IdMainTemp = model.MainTemp.Id;

            return this;
        }

        public ItemTemp ToModel()
        {
            return new ItemTemp
            {
                Id = Id,
                Item = new Item
                {
                    Id = IdItem
                },
                MainTemp = new MainTemp
                {
                    Id = IdMainTemp
                }
            };
        }
    }
}