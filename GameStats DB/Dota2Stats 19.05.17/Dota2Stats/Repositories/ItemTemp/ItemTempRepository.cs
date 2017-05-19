using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.ItemTemp
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;


    public class ItemTempRepository : IItemTempRepository
    {
        public IEnumerable<ItemTemp> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().ToList();
            }
        }

        public ItemTemp Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public ItemTemp Insert(ItemTemp model)
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

        public ItemTemp Update(int id, ItemTemp model)
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
                    ItemTemp itemTemp = session.Query<ItemTemp>().Where(x => x.Id == id).SingleOrDefault();
                    session.Delete(itemTemp);
                    transaction.Commit();
                    return true;
                }
            }
        }
        public IEnumerable<ItemTemp> GetItemTempByIdMainTemp(int idMainTemp)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().Where(x => x.MainTemp.Id == idMainTemp).ToList();
            }
        }

        public IEnumerable<ItemTemp> GetItemTempByIdItem(int idItem)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().Where(x => x.Item.Id == idItem).ToList();
            }
        }
    }
}