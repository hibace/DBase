using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using NHibernate.Transaction;

namespace Dota2Stats.Repositories.Player
{
    using Models;
    using Dota2Stats.Middleware;
    using Npgsql;
    using System.Reflection;
    using NHibernate;


    public class PlayerRepository : IPlayerRepository
    {
        ISession session;
        public PlayerRepository(ISession session)
        {
            this.session = session;
        }

        public List<Player> GetAll()
        {
            return session.Query<Player>().ToList();
        }

        public Player Get(int id)
        {
            return session.Get<Player>(id);
        }

        public Player Insert(Player model)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(model);
                transaction.Commit();
                return model;
            }
        }

        public Player Update(int id, Player model)
        {
            using (var transaction = session.BeginTransaction())
            {
                var item = session.Get<Player>(id);
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
                session.Delete(session.Get<Player>(id));
                transaction.Commit();
                return true;
            }
        }

        public List<Player> GetPlayerByNickName(string nickName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().Where(x => x.Nickname == nickName).ToList();
            }
        }

        public List<Player> GetPlayerByNumberOfGames(int numberOfGames)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Player>().Where(x => x.NumberOfGames >= numberOfGames).ToList();
            }
        }
    }
}