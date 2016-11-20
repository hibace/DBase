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

    public class matchtempController : ApiController
    {
        // GET api/matchtemp
        public IEnumerable<Matchtemp> Get()
        {
            var matchtemp = new List<Matchtemp>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM matchtemp ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matchtemp.Add(new Matchtemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_match = reader.GetInt32(2)
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
            return matchtemp;
        }

        // GET api/matchtemp/5
        public Matchtemp Get(int id)
        {
            Matchtemp matchtemp = new Matchtemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM matchtemp WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matchtemp = new Matchtemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_match = reader.GetInt32(2)
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
            return matchtemp;
        }

        // POST api/matchtemp
        public Matchtemp Post([FromBody]Matchtemp value)
        {
            Matchtemp insertedMatchtemp = new Matchtemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO matchtemp (id_maintemp, id_match) VALUES (@id_maintemp, @id_match)";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_match", value.id_match));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM matchtemp ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedMatchtemp = new Matchtemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_match = reader.GetInt32(2)
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
            return insertedMatchtemp;
        }

        // PUT api/matchtemp/5
        public Matchtemp Put(int id, [FromBody]Matchtemp value)
        {
            Matchtemp updatedMatchtemp = new Matchtemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE matchtemp SET id_maintemp=@id_maintemp, id_match=@id_match WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_match", value.id_match));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM matchtemp WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedMatchtemp = new Matchtemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_match = reader.GetInt32(2)
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
            return updatedMatchtemp;
        }

        // DELETE api/matchtemp/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM matchtemp WHERE id=@id";
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