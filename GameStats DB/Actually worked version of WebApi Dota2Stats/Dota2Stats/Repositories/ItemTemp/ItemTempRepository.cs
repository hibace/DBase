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
    using System.Reflection;
    using NHibernate;


    public class ItemTempRepository : IItemTempRepository
    {
        ISession session;
        public ItemTempRepository(ISession session)
        {
            this.session = session;
        }

        public List<ItemTemp> GetAll()
        {
            return session.Query<ItemTemp>().ToList();
        }

        public ItemTemp Get(int id)
        {
            return session.Get<ItemTemp>(id);
        }

        public ItemTemp Insert(ItemTemp model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public ItemTemp Update(int id, ItemTemp model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<ItemTemp>(id);
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
                session.Delete(session.Get<ItemTemp>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<ItemTemp> GetItemTempByIdMainTemp(int idMainTemp)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().Where(x => x.MainTemp.Id == idMainTemp).ToList();
            }
        }

        public List<ItemTemp> GetItemTempByIdItem(int idItem)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<ItemTemp>().Where(x => x.Item.Id == idItem).ToList();
            }
        }
    }
}