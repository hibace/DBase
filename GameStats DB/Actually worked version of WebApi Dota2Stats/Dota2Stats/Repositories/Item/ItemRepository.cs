using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Item
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class ItemRepository : IItemRepository
    {
        ISession session;
        public ItemRepository(ISession session)
        {
            this.session = session;
        }

        public List<Item> GetAll()
        {
            return session.Query<Item>().ToList();
        }

        public Item Get(int id)
        {
            return session.Get<Item>(id);
        }

        public Item Insert(Item model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public Item Update(int id, Item model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<Item>(id);
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
                session.Delete(session.Get<Item>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<Item> GetItemByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().Where(x => x.Name == name).ToList();
            }
        }

        public List<Item> GetItemByType(string type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().Where(x => x.Type == type).ToList();
            }
        }
    }
}