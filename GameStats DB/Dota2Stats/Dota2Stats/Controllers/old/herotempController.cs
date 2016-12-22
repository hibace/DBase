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

    public class herotempController : ApiController
    {
        // GET api/herotemp
        public IEnumerable<Herotemp> Get()
        {
            var herotemp = new List<Herotemp>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM herotemp ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            herotemp.Add(new Herotemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_hero = reader.GetInt32(2)
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
            return herotemp;
        }

        // GET api/herotemp/5
        public Herotemp Get(int id)
        {
            Herotemp herotemp = new Herotemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM herotemp WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            herotemp = new Herotemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_hero = reader.GetInt32(2)
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
            return herotemp;
        }

        // POST api/herotemp
        public Herotemp Post([FromBody]Herotemp value)
        {
            Herotemp insertedHerotemp = new Herotemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO herotemp (id_maintemp, id_hero) VALUES (@id_maintemp, @id_hero)";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM herotemp ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedHerotemp = new Herotemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_hero = reader.GetInt32(2)
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
            return insertedHerotemp;
        }

        // PUT api/herotemp/5
        public Herotemp Put(int id, [FromBody]Herotemp value)
        {
            Herotemp updatedHerotemp = new Herotemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE herotemp SET id_maintemp=@id_maintemp, id_hero=@id_hero WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM herotemp WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedHerotemp = new Herotemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_hero = reader.GetInt32(2)
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
            return updatedHerotemp;
        }

        // DELETE api/herotemp/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM herotemp WHERE id=@id";
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