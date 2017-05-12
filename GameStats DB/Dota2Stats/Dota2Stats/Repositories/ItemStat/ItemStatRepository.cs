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


    public class ItemStatRepository : IItemStatRepository
    {
        public IEnumerable<ItemStat> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().ToList();
            }
        }

        public ItemStat Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public ItemStat Insert(ItemStat model)
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

        public ItemStat Update(int id, ItemStat model)
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
                    ItemStat itemStat = session.Query<ItemStat>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(itemStat);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public IEnumerable<ItemStat> GetItemStatByTimeUsed(int timeUsed)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().Where(x => x.TimeUsed == timeUsed).ToList();
            }
        }

        public IEnumerable<ItemStat> GetItemStatByIdItem(int idItem)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemStat>().Where(x => x.Item.Id == idItem).ToList();
            }
        }
    }
}