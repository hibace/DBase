using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Dota2Stats.Models;
using Dota2Stats.Middleware;
using Npgsql;

namespace Dota2Stats.Controllers
{
    using Middleware;

    public class heroController : ApiController
    {
        //// GET api/hero
        public IEnumerable<Hero> Get()
        {
            var heroes = new List<Hero>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM hero ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            heroes.Add(new Hero
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                hero_class = reader.GetString(2),
                                role = reader.GetString(3)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                NpgsqlHelper.Connection.Close();
            }
            NpgsqlHelper.Connection.Close();
            return heroes;
        }

        // GET api/hero/5
        public Hero Get(int id)
        {
            Hero hero = new Hero();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM hero WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hero = new Hero
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    hero_class = reader.GetString(2),
                                    role = reader.GetString(3)
                                };
                            }
                        }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            NpgsqlHelper.Connection.Close();
            return hero;
        }

        //POST api/hero
        public Hero Post([FromBody]Hero value)
        {            
            Hero insertedHero = new Hero();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO hero (name, hero_class, role) VALUES (@name, @hero_class, @role)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", value.name));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_class", value.hero_class));
                cmd.Parameters.Add(new NpgsqlParameter("@role", value.role));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM hero ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedHero = new Hero
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    hero_class = reader.GetString(2),
                                    role = reader.GetString(3)
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    cmd2.ExecuteNonQuery();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Dispose();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            NpgsqlHelper.Connection.Close();
            return insertedHero;
        }

        //PUT api/hero/5
        public Hero Put(int id, [FromBody]Hero value)
        {
            Hero updatedHero = new Hero();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE hero SET name=@name, hero_class=@hero_class, role=@role WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", value.name));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_class", value.hero_class));
                cmd.Parameters.Add(new NpgsqlParameter("@role", value.role));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM hero WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedHero = new Hero
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    hero_class = reader.GetString(2),
                                    role = reader.GetString(3)
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    cmd2.ExecuteNonQuery();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Dispose();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            NpgsqlHelper.Connection.Close();
            return updatedHero;
        }

        // DELETE api/hero/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM hero WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            NpgsqlHelper.Connection.Close();
        }
    }
}
