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
    public class maintempController : ApiController
    {
        // GET api/maintemp
        public IEnumerable<MainTemp> Get()
        {
            var maintemp = new List<MainTemp>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM maintemp ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maintemp.Add(new MainTemp
                            {
                                id = reader.GetInt32(0),
                                id_player = reader.GetInt32(1),
                                id_hero = reader.GetInt32(2),
                                id_match = reader.GetInt32(3),
                                id_item = reader.GetInt32(4)
                            });
                        }
                    }
                }
                catch (Exception)
                {

                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                NpgsqlHelper.Connection.Close();
            }
            NpgsqlHelper.Connection.Close();
            return maintemp;
        }

        // GET api/maintemp/5
        public MainTemp Get(int id)
        {
            MainTemp maintemp = new MainTemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM maintemp WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maintemp = new MainTemp
                            {
                                id = reader.GetInt32(0),
                                id_player = reader.GetInt32(1),
                                id_hero = reader.GetInt32(2),
                                id_match = reader.GetInt32(3),
                                id_item = reader.GetInt32(4)
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
            return maintemp;
        }

        // POST api/maintemp
        public MainTemp Post([FromBody]MainTemp value)
        {
            MainTemp insertedMaintemp = new MainTemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO maintemp (id_player, id_hero, id_match) VALUES (@id_player, @id_hero, @id_match)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.Parameters.Add(new NpgsqlParameter("@id_match", value.id_match));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM maintemp ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedMaintemp = new MainTemp
                                {
                                    id = reader.GetInt32(0),
                                    id_player = reader.GetInt32(1),
                                    id_hero = reader.GetInt32(2),
                                    id_match = reader.GetInt32(3),
                                    id_item = reader.GetInt32(4)
                                };
                            }
                        }
                    }
                    catch (Exception)
                    {

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
            return insertedMaintemp;
        }

        // PUT api/maintemp/5
        public MainTemp Put(int id, [FromBody]MainTemp value)
        {
            MainTemp updatedMaintemp = new MainTemp();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE maintemp SET id_player=@id_player, id_hero=@id_hero, id_match=@id_match WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.Parameters.Add(new NpgsqlParameter("@id_hero", value.id_hero));
                cmd.Parameters.Add(new NpgsqlParameter("@id_match", value.id_match));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM maintemp WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedMaintemp = new MainTemp
                                {
                                    id = reader.GetInt32(0),
                                    id_player = reader.GetInt32(1),
                                    id_hero = reader.GetInt32(2),
                                    id_match = reader.GetInt32(3),
                                    id_item = reader.GetInt32(4)
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
                catch (Exception)
                {

                }
            }
            NpgsqlHelper.Connection.Close();
            return updatedMaintemp;
        }

        // DELETE api/maintemp/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM maintemp WHERE id=@id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {

                }
            }
            NpgsqlHelper.Connection.Close();
        }
    }
}
