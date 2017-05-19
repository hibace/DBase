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


    public class ItemRepository : IItemRepository
    {
        public IEnumerable<Item> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().ToList();
            }
        }

        public Item Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public Item Insert(Item model)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    model.Id = 0;
                    session.Save(model);
                    transaction.Commit();
                }
            }
            return model;
        }

        public Item Update(int id, Item model)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    model.Id = id;
                    session.Update(model);
                    transaction.Commit();
                }
            }
            return model;
        }

        public bool Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    Item item = session.Query<Item>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(item);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<Item> GetItemByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().Where(x => x.Name == name).ToList();
            }
        }

        public IEnumerable<Item> GetItemByType(string type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Item>().Where(x => x.Type == type).ToList();
            }
        }
    }
}