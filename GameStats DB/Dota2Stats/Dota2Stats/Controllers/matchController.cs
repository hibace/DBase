﻿using System;
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
    public class matchController : ApiController
    {
        // GET api/match
        public IEnumerable<Match> Get()
        {
            var match = new List<Match>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM match ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            match.Add(new Match
                            {
                                id = reader.GetInt32(0),
                                duration = reader.GetInt32(1),
                                date = reader.GetString(2),
                                game_mode = reader.GetString(3)
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
            return match;
        }

        // GET api/match/5
        public Match Get(int id)
        {
            Match match = new Match();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM match WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            match = new Match
                            {
                                id = reader.GetInt32(0),
                                duration = reader.GetInt32(1),
                                date = reader.GetString(2),
                                game_mode = reader.GetString(3)
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
            return match;
        }

        // POST api/match
        public Match Post([FromBody]Match value)
        {
            Match insertedMatch = new Match();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO match (duration, date, game_mode) VALUES (@duration, @date, @game_mode)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@duration", value.duration));
                cmd.Parameters.Add(new NpgsqlParameter("@date", value.date));
                cmd.Parameters.Add(new NpgsqlParameter("@game_mode", value.game_mode));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM match ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedMatch = new Match
                                {
                                    id = reader.GetInt32(0),
                                    duration = reader.GetInt32(1),
                                    date = reader.GetString(2),
                                    game_mode = reader.GetString(3)
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
            return insertedMatch;
        }

        // PUT api/match/5
        public Match Put(int id, [FromBody]Match value)
        {
            Match updatedMatch = new Match();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE match SET duration=@duration, date=@date, game_mode=@game_mode WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@duration", value.duration));
                cmd.Parameters.Add(new NpgsqlParameter("@date", value.date));
                cmd.Parameters.Add(new NpgsqlParameter("@game_mode", value.game_mode));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM match WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedMatch = new Match
                                {
                                    id = reader.GetInt32(0),
                                    duration = reader.GetInt32(1),
                                    date = reader.GetString(2),
                                    game_mode = reader.GetString(3)
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
            return updatedMatch;
        }

        // DELETE api/match/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM match WHERE id=@id";
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