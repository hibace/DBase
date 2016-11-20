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
    public class hero_statController : ApiController
    {
        // GET api/hero_stat
        public IEnumerable<Hero_stat> Get()
        {
            var hero_stat = new List<Hero_stat>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM hero_stat ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hero_stat.Add(new Hero_stat
                            {
                                id = reader.GetInt32(0),
                                id_hero = reader.GetInt32(1),
                                hero_damage = reader.GetInt32(2),
                                hero_healing = reader.GetInt32(3),
                                tower_damage = reader.GetInt32(4)
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
            return hero_stat;
        }

        // GET api/hero_stat/5
        public Hero_stat Get(int id)
        {
            Hero_stat hero_stat = new Hero_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM hero_stat WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hero_stat = new Hero_stat
                            {
                                id = reader.GetInt32(0),
                                id_hero = reader.GetInt32(1),
                                hero_damage = reader.GetInt32(2),
                                hero_healing = reader.GetInt32(3),
                                tower_damage = reader.GetInt32(4)
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
            return hero_stat;
        }

        // POST api/hero_stat
        public Hero_stat Post([FromBody]Hero_stat value)
        {
            Hero_stat insertedHero_stat = new Hero_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO hero_stat (id_hero, hero_damage, hero_healing, tower_damage) VALUES (@id_hero, @hero_damage, @hero_healing, @tower_damage)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_damage", value.hero_damage));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_healing", value.hero_healing));
                cmd.Parameters.Add(new NpgsqlParameter("@tower_damage", value.tower_damage));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM hero_stat ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedHero_stat = new Hero_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_hero = reader.GetInt32(1),
                                    hero_damage = reader.GetInt32(2),
                                    hero_healing = reader.GetInt32(3),
                                    tower_damage = reader.GetInt32(4)
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
            return insertedHero_stat;
        }

        // PUT api/hero_stat/5
        public Hero_stat Put(int id, [FromBody]Hero_stat value)
        {
            Hero_stat updatedHero_stat = new Hero_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE hero_stat SET id_hero=@id_hero, hero_damage=@hero_damage, hero_healing=@hero_healing, tower_damage=@tower_damage WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_damage", value.hero_damage));
                cmd.Parameters.Add(new NpgsqlParameter("@hero_healing", value.hero_healing));
                cmd.Parameters.Add(new NpgsqlParameter("@tower_damage", value.tower_damage));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM hero_stat WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedHero_stat = new Hero_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_hero = reader.GetInt32(1),
                                    hero_damage = reader.GetInt32(2),
                                    hero_healing = reader.GetInt32(3),
                                    tower_damage = reader.GetInt32(4)
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
            return updatedHero_stat;
        }

        // DELETE api/hero_stat/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM hero_stat WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
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
