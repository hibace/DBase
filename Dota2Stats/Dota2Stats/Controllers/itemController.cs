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
    public class itemController : ApiController
    {
        // GET api/item
        public IEnumerable<Item> Get()
        {
            var item = new List<Item>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM item ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item.Add(new Item
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                type = reader.GetString(2)
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
            return item;
        }

        // GET api/item/5
        public Item Get(int id)
        {
            Item item = new Item();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM item WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new Item
                            {
                                id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                type = reader.GetString(2)
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
            return item;
        }

        // POST api/item
        public Item Post([FromBody]Item value)
        {
            Item insertedItem = new Item();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO item (name, type) VALUES (@name, @type)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", value.name));
                cmd.Parameters.Add(new NpgsqlParameter("@type", value.type));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM item ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedItem = new Item
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    type = reader.GetString(2)
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
            return insertedItem;
        }

        // PUT api/item/5
        public Item Put(int id, [FromBody]Item value)
        {
            Item updatedItem = new Item();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE item SET name=@name, type=@type WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@name", value.name));
                cmd.Parameters.Add(new NpgsqlParameter("@type", value.type));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM item WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedItem = new Item
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    type = reader.GetString(2)
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
            return updatedItem;
        }

        // DELETE api/item/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM item WHERE id=@id";
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
