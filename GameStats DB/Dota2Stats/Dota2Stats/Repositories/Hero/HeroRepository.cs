using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Hero
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;

    public class HeroRepository : IHeroRepository
    {
        ISession session;
        public HeroRepository(ISession session)
        {
            this.session = session;
        }

        public List<Hero> GetAll()
        {
            return session.Query<Hero>().ToList();
        }

        public Hero Get(int id)
        {
            return session.Get<Hero>(id);
        }
        

        public Hero Insert(Hero model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }


        public Hero Update(int id, Hero model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<Hero>(id);
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
                session.Delete(session.Get<Hero>(id));
                transaction.Commit();
                return true;
            }
        }
        
        public List<Hero> GetHeroByName(string name)
        {
            return session.Query<Hero>().Where(x => x.Name == name).ToList(); 
        }

        public List<Hero> GetHeroByClass(string heroClass)
        {
            return session.Query<Hero>().Where(x => x.HeroClass == heroClass).ToList(); 
        }

        public List<Hero> GetHeroByRole(string role)
        {
            return session.Query<Hero>().Where(x => x.Role == role).ToList(); 
        }
    }
}