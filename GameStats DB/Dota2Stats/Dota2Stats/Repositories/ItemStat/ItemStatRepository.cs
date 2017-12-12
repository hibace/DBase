using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.ItemStat
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class ItemStatRepository : IItemStatRepository
    {
        ISession session;
        public ItemStatRepository(ISession session)
        {
            this.session = session;
        }

        public List<ItemStat> GetAll()
        {
            return session.Query<ItemStat>().ToList();
        }

        public ItemStat Get(int id)
        {
            return session.Get<ItemStat>(id);
        }

        public ItemStat Insert(ItemStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public ItemStat Update(int id, ItemStat model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<ItemStat>(id);
                foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.Name != "Id"))
                {
                    property.SetValue(item, property.GetValue(model));
                }
                session.Update(item);
                transaction.Commit();
                return item;
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(session.Get<ItemStat>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<ItemStat> GetItemStatByTimeUsed(int timeUsed)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().Where(x => x.TimeUsed == timeUsed).ToList();
            }
        }

        public List<ItemStat> GetItemStatByIdItem(int idItem)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().Where(x => x.Item.Id == idItem).ToList();
            }
        }
    }
}