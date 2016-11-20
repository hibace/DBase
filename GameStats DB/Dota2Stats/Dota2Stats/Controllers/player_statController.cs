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
    public class player_statController : ApiController
    {
        // GET api/player_stat
        public IEnumerable<Player_stat> Get()
        {
            var player_stat = new List<Player_stat>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM player_stat ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player_stat.Add(new Player_stat
                            {
                                id = reader.GetInt32(0),
                                id_player = reader.GetInt32(1),
                                verified = reader.GetBoolean(2),
                                time_spent_playing = reader.GetInt32(3),
                                most_matches_played = reader.GetInt32(4)
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
            return player_stat;
        }

        // GET api/player_stat/5
        public Player_stat Get(int id)
        {
            Player_stat player_stat = new Player_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM player_stat WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            player_stat = new Player_stat
                            {
                                id = reader.GetInt32(0),
                                id_player = reader.GetInt32(1),
                                verified = reader.GetBoolean(2),
                                time_spent_playing = reader.GetInt32(3),
                                most_matches_played = reader.GetInt32(4)
                            };
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            NpgsqlHelper.Connection.Close();
            return player_stat;
        }

        // POST api/player_stat
        public Player_stat Post([FromBody]Player_stat value)
        {
            Player_stat insertedPlayer_stat = new Player_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO player_stat (id_player, verified, time_spent_playing, most_matches_played) VALUES (@id_player, @verified, @time_spent_playing, @most_matches_played)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.Parameters.Add(new NpgsqlParameter("@verified", value.verified));
                cmd.Parameters.Add(new NpgsqlParameter("@time_spent_playing", value.time_spent_playing));
                cmd.Parameters.Add(new NpgsqlParameter("@most_matches_played", value.most_matches_played));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM player_stat ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedPlayer_stat = new Player_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_player = reader.GetInt32(1),
                                    verified = reader.GetBoolean(2),
                                    time_spent_playing = reader.GetInt32(3),
                                    most_matches_played = reader.GetInt32(4)
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
                    
                }
            }
            NpgsqlHelper.Connection.Close();
            return insertedPlayer_stat;
        }

        // PUT api/player_stat/5
        public Player_stat Put(int id, [FromBody]Player_stat value)
        {
            Player_stat updatedPlayer_stat = new Player_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE player_stat SET id_player=@id_player, verified=@verified, time_spent_playing=@time_spent_playing most_matches_played=@most_matches_played WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_player", value.id_player));
                cmd.Parameters.Add(new NpgsqlParameter("@verified", value.verified));
                cmd.Parameters.Add(new NpgsqlParameter("@time_spent_playing", value.time_spent_playing));
                cmd.Parameters.Add(new NpgsqlParameter("@most_matches_played", value.most_matches_played));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM player_stat WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedPlayer_stat = new Player_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_player = reader.GetInt32(1),
                                    verified = reader.GetBoolean(2),
                                    time_spent_playing = reader.GetInt32(3),
                                    most_matches_played = reader.GetInt32(4)
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
            return updatedPlayer_stat;
        }

        // DELETE api/player_stat/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM player_stat WHERE id=@id";
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
