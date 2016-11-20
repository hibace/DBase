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

    public class playertempController : ApiController
    {
        // GET api/playertemp
        public IEnumerable<Playertemp> Get()
        {
            var playertemp = new List<Playertemp>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM playertemp ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            playertemp.Add(new Playertemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_player = reader.GetInt32(2)
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
            return playertemp;
        }

        // GET api/playertemp/5
        public Playertemp Get(int id)
        {
            Playertemp playertemp = new Playertemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM playertemp WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            playertemp = new Playertemp
                            {
                                id = reader.GetInt32(0),
                                id_maintemp = reader.GetInt32(1),
                                id_player = reader.GetInt32(2)
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
            return playertemp;
        }

        // POST api/playertemp
        public Playertemp Post([FromBody]Playertemp value)
        {
            Playertemp insertedPlayertemp = new Playertemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO playertemp (id_maintemp, id_player) VALUES (@id_maintemp, @id_player)";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM playertemp ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedPlayertemp = new Playertemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_player = reader.GetInt32(2)
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
            return insertedPlayertemp;
        }

        // PUT api/playertemp/5
        public Playertemp Put(int id, [FromBody]Playertemp value)
        {
            Playertemp updatedPlayertemp = new Playertemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE playertemp SET id_maintemp=@id_maintemp, id_player=@id_player WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_maintemp", value.id_maintemp));
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM playertemp WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedPlayertemp = new Playertemp
                                {
                                    id = reader.GetInt32(0),
                                    id_maintemp = reader.GetInt32(1),
                                    id_player = reader.GetInt32(2)
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
            return updatedPlayertemp;
        }

        // DELETE api/playertemp/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM playertemp WHERE id=@id";
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