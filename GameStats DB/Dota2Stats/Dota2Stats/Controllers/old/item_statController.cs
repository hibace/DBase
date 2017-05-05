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
    public class item_statController : ApiController
    {
        // GET api/item_stat?time_used_less_than=10
        public IEnumerable<Item_stat> GetByTimeUsed(int time_used_less_than)
        {
            var item_stat = new List<Item_stat>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.Parameters.Add(new NpgsqlParameter("@time_used_less_than", time_used_less_than));
                cmd.CommandText = "SELECT * FROM item_stat WHERE time_used < @time_used_less_than";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item_stat.Add(new Item_stat
                            {
                                id = reader.GetInt32(0),
                                id_item = reader.GetInt32(1),
                                time_used = reader.GetInt32(2)
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
            return item_stat;
        }

        // GET api/item_stat
        public IEnumerable<Item_stat> Get()
        {
            var item_stat = new List<Item_stat>();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM item_stat ORDER by id ASC";
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item_stat.Add(new Item_stat
                            {
                                id = reader.GetInt32(0),
                                id_item = reader.GetInt32(1),
                                time_used = reader.GetInt32(2)
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
            return item_stat;
        }

        // GET api/item_stat/5
        public Item_stat Get(int id)
        {
            Item_stat item_stat = new Item_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "SELECT * FROM item_stat WHERE id = @id ORDER by id ASC";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                try
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item_stat = new Item_stat
                            {
                                id = reader.GetInt32(0),
                                id_item = reader.GetInt32(1),
                                time_used = reader.GetInt32(2)
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
            return item_stat;
        }

        // POST api/item_stat
        public Item_stat Post([FromBody]Item_stat value)
        {
            Item_stat insertedItem_stat = new Item_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "INSERT INTO item_stat (id_item, time_used) VALUES (@id_item, @time_used)";
                //cmd.Parameters.Add(new NpgsqlParameter("@id", value.id));
                cmd.Parameters.Add(new NpgsqlParameter("@id_item", value.id_item));
                cmd.Parameters.Add(new NpgsqlParameter("@time_used", value.time_used));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM item_stat ORDER BY id DESC LIMIT 1";
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                insertedItem_stat = new Item_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_item = reader.GetInt32(1),
                                    time_used = reader.GetInt32(2)
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
            return insertedItem_stat;
        }

        // PUT api/item_stat/5
        public Item_stat Put(int id, [FromBody]Item_stat value)
        {
            Item_stat updatedItem_stat = new Item_stat();
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgsqlHelper.Connection;
                cmd.CommandText = "UPDATE item_stat SET id_item=@id_item, time_used=@time_used WHERE id=@id";
                cmd.Parameters.Add(new NpgsqlParameter("@id_item", value.id_item));
                cmd.Parameters.Add(new NpgsqlParameter("@time_used", value.time_used));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();

                try
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = NpgsqlHelper.Connection;
                    cmd2.CommandText = "SELECT * FROM item_stat WHERE id = @id";
                    cmd2.Parameters.Add(new NpgsqlParameter("@id", id));
                    try
                    {
                        using (var reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                updatedItem_stat = new Item_stat
                                {
                                    id = reader.GetInt32(0),
                                    id_item = reader.GetInt32(1),
                                    time_used = reader.GetInt32(2)
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
            return updatedItem_stat;
        }

        // DELETE api/item_stat/5
        public void Delete(int id)
        {
            NpgsqlHelper.Connection.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                try
                {
                    cmd.Connection = NpgsqlHelper.Connection;
                    cmd.CommandText = "DELETE FROM item_stat WHERE id=@id";
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
